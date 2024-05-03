using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHold : MonoBehaviour
{
    
    public GameObject Object;
    public Transform PlayerTransform;
    public float range = 3f;
    public float Go = 100f;
    public Camera Camera;
    int holding = 0;


    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            StartPickUp();
            Debug.Log("Picked Up");
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            Drop();
            Debug.Log("Dropped");
        }
    }

    void StartPickUp ()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.transform.position, Camera.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                PickUp();
            }
        }
    }

    void PickUp ()
    {
        GetComponent<Rigidbody>().isKinematic = true;
        Object.GetComponent<Rigidbody>().useGravity = false;
        Object.transform.SetParent(PlayerTransform);
    }

    void Drop ()
    {
        PlayerTransform.DetachChildren();
        GetComponent<Rigidbody>().isKinematic = false;
        Object.GetComponent<Rigidbody>().useGravity = true;

    }

     private IEnumerator PickUpSwitch()
    { 
            yield return new WaitForSeconds(1);
            holding = 1;
        

    }
    
}
