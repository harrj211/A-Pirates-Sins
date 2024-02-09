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
    
    
    private IEnumerator Reload()
    { 
            yield return new WaitForSeconds(reloadTime);
            txt.text = "1/∞";
            Ammo = 1;
            canR = 1;
        

    }
}
