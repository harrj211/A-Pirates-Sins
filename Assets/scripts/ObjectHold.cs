using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHold : MonoBehaviour
{

    public Transform PlayerTransform;
    public float range = 3f;
    public Camera Camera;
    int holding = 0;
    GameObject Uppies;


    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && holding == 0)
        {
            StartPickUp();

            StartCoroutine(HoldingOn());
        }

        if (Input.GetKeyDown(KeyCode.Q) && holding == 1)
        {
            Drop();

            StartCoroutine(HoldingOff());
        }
    }

    void StartPickUp ()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.transform.position, Camera.transform.forward, out hit, range))
        {


            if (hit.collider.tag == "canPickUp")
            {
                Uppies = hit.collider.gameObject;
                hit.transform.GetComponent<Rigidbody>();

                PickUp();
                    
            //if (hit.collider.tag == "namehere")
            }
        
        }
    }

    void PickUp ()
    {
        Uppies.GetComponent<Rigidbody>().isKinematic = true;
        Uppies.GetComponent<Rigidbody>().useGravity = false;
        Uppies.transform.SetParent(PlayerTransform);
    }

    void Drop ()
    {
        PlayerTransform.DetachChildren();
        Uppies.GetComponent<Rigidbody>().isKinematic = false;
        Uppies.GetComponent<Rigidbody>().useGravity = true;

    }

    private IEnumerator HoldingOn()
    { 
            yield return new WaitForSeconds(1);
            holding = 1;    
    }

    private IEnumerator HoldingOff()
    { 
            yield return new WaitForSeconds(1);
            holding = 0;
    }
    
}
