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
    public AudioClip clip;
    public float volume;
    //Cooldown timer
    public float buttonDelay = 3.0f; //the delay between button presses
    float lastButtonTime = 0; //cache the last pressed time


    Vector3 launcher;

    void Update()
    {
        m_fieldofview = 60f;

        if (Input.GetButton("Fire1") && Time.time >= lastButtonTime)
        {
         
           lastButtonTime = Time.time + buttonDelay;

            audioSource.PlayOneShot(clip, volume);

            GameObject ball = Instantiate(projectile, transform.position, transform.rotation);
            ball.GetComponent<Rigidbody>().AddRelativeForce(new Vector3 (0, 0, launchVelocity));

             muzzleflash.Play();
          
        }

        else
        {
            muzzleflash.Stop();
        }

        if (Input.GetButton("Fire2"))
        {
            m_fieldofview = 10f;
        }



    Camera.main.fieldOfView = m_fieldofview;
    }
    

}
