using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchProjectile : MonoBehaviour
{
    public GameObject projectile;
    public float launchVelocity = 700f;
    public ParticleSystem muzzleflash;
    float m_fieldofview;
    public AudioSource audioSource;
    public AudioClip clip;
    public float volume;


    Vector3 launcher;

    void Update()
    {
        m_fieldofview = 60f;

        if (Input.GetButtonDown("Fire1"))
        {
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
