using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LaunchProjectile : MonoBehaviour
{
    //Projectile Launching
    public GameObject projectile;
    public float launchVelocity = 700f;
    public ParticleSystem muzzleflash;
    //Field of view
    float m_fieldofview;
    //Audio (Song)
    public AudioSource audioSource;
   public float volume;
   public float shotvolume;
   public float clickvolume;

    public int Ammo;
    public float reloadTime;
    public int canR;

    public AudioClip click;
    public AudioClip shot;
    public AudioClip reload;

    public TMP_Text txt;

    [SerializeField] float explosionForce = 10;
    [SerializeField] float explosionRadius = 10;
    Collider[] colliders = new Collider[2000];




    Vector3 launcher;

    void Start()
    {
        txt.text = "1/∞";
        Ammo = 1;
        canR = 1;
        
    }

    void Update()
    {
        m_fieldofview = 60f;

        if (Input.GetButtonDown("Fire1") && Ammo > 0)
        {
            audioSource.PlayOneShot(shot, shotvolume);

            GameObject ball = Instantiate(projectile, transform.position, transform.rotation);
            ball.GetComponent<Rigidbody>().AddRelativeForce(new Vector3 (0, 0, launchVelocity));

            ExplodeNonAlloc();

             muzzleflash.Play();

             Ammo = 0;

             txt.text = "0/∞";
            
          
        }

        else
        {
            muzzleflash.Stop();
        }

        if (Input.GetButton("Fire2"))
        {
            m_fieldofview = 26f;
        }

        if (Input.GetButtonDown("Fire1") && Ammo <= 0)
        {
            audioSource = GetComponent<AudioSource>();
            audioSource.PlayOneShot(click, clickvolume);
        }

        if (Input.GetKeyDown (KeyCode.R) && canR > 0 && Ammo <= 0)
        {

		    StartCoroutine(Reload());
            audioSource.PlayOneShot(reload, volume);
            canR = 0;
         
        }

    Camera.main.fieldOfView = m_fieldofview;
    }

    void ExplodeNonAlloc()
    {
        
        //Debug.Log("Do something here");
        int numColliders = Physics.OverlapSphereNonAlloc(transform.position, explosionRadius, colliders);
        if (numColliders > 0)
        {
            for (int i = 0; i < numColliders; i++)
            {
                //Debug.Log("colliders = " + numColliders);
                //Debug.Log("i =" + i);

                if (colliders[i].TryGetComponent(out Rigidbody rb))
                {
                    rb.AddExplosionForce(explosionForce, transform.position, explosionRadius, 1);
                    //Debug.Log("transform = " + transform);
                    //Debug.Log("force = " + explosionForce);
                    //Debug.Log("radius = " + explosionRadius);
                    //Debug.Log("rb = " + rb);
                    //Debug.Log("boom");
                    
                    
                }
            }
        }
    }
    
    
    private IEnumerator Reload()
    { 
            yield return new WaitForSeconds(reloadTime);
            txt.text = "1/∞";
            Ammo = 1;
            canR = 1;
        

    }
}
