using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannonball : MonoBehaviour
{
    public Rigidbody rbs;
    public int canHit = 1;
    public ParticleSystem crash;
    public Transform direction;
    public GameObject self;
    public AudioClip collide;
    public float volume;
    [SerializeField] float explosionForce = 10;
    [SerializeField] float explosionRadius = 10;
    Collider[] colliders = new Collider[2000];


    // Update is called once per frame
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
    // Start is called before the first frame update
    void Start()
    {
    

    }

    // Update is called once per frame
    void Update()
    {
    
    }

//Detect collisions between the GameObjects with Colliders attached
    void OnCollisionEnter(Collision collision)
    {
         GetComponent<AudioSource>().PlayOneShot(collide, volume);
        
        
        if (canHit == 1)
        {
            crash.Play();
            canHit = 0;
            ExplodeNonAlloc();
        }

        

        //Check for a match with the specified name on any GameObject that collides with your GameObject
    }

    
}
