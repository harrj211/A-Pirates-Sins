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
        if (Input.GetKeyDown(KeyCode.Q) && holding == 0)
        {
            StartPickUp();
            Debug.Log("Picked Up");
            StartCoroutine(HoldingOn());
        }

        if (Input.GetKeyDown(KeyCode.Q) && holding == 1)
        {
            Drop();
            Debug.Log("Dropped");
            StartCoroutine(HoldingOff());
        }
    }

    void StartPickUp ()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.transform.position, Camera.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            hit.transform.GetComponent<Rigidbody>();
            if (gameObject.tag == "canPickUp")
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
