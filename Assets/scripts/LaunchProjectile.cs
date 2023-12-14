using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
    public int Ammo;
    public AudioClip click;
    public AudioClip shot;



    Vector3 launcher;

    void Start()
    {
        Ammo = 1;
        
    }

    void Update()
    {
        m_fieldofview = 60f;

        if (Input.GetButtonDown("Fire1") && Ammo > 0)
        {
            audioSource.PlayOneShot(shot, volume);

            GameObject ball = Instantiate(projectile, transform.position, transform.rotation);
            ball.GetComponent<Rigidbody>().AddRelativeForce(new Vector3 (0, 0, launchVelocity));

             muzzleflash.Play();

             Ammo = 0;
            
          
        }

        else
        {
            muzzleflash.Stop();
        }

        if (Input.GetButton("Fire2"))
        {
            m_fieldofview = 10f;
        }

        if (Input.GetButtonDown("Fire1") && Ammo <= 0)
        {
            audioSource = GetComponent<AudioSource>();
            audioSource.PlayOneShot(click, volume);
        }

        if (Input.GetKeyDown (KeyCode.R))
        {
		    Ammo = 1;
         
        }

    Camera.main.fieldOfView = m_fieldofview;
    }
    
    private void UpdateAmmoText()
    {
    
    }
}
