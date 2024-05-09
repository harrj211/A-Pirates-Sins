using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHold : MonoBehaviour
{

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

            if(hit.transform.CompareTag("canPickUp"))
            {
                hit.transform.GetComponent<Rigidbody>();

                if (GameObject.FindWithTag("canPickUp"))
                PickUp();
            }
        
        }
    }

    void PickUp ()
    {
        GameObject.FindWithTag("canPickUp").GetComponent<Rigidbody>().isKinematic = true;
        GameObject.FindWithTag("canPickUp").GetComponent<Rigidbody>().useGravity = false;
        GameObject.FindWithTag("canPickUp").transform.SetParent(PlayerTransform);
    }

    void Drop ()
    {
        PlayerTransform.DetachChildren();
        GameObject.FindWithTag("canPickUp").GetComponent<Rigidbody>().isKinematic = false;
        GameObject.FindWithTag("canPickUp").GetComponent<Rigidbody>().useGravity = true;

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
