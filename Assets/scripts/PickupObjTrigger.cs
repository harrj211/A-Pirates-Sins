using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonPickUp : MonoBehaviour
{

    public GameObject CollectedObj;
    public GameObject Self;

    // Start is called before the first frame update
    void Start()
    {
        CollectedObj.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player" && Input.GetKey(KeyCode.E))
        {
            Self.SetActive(false);
            CollectedObj.SetActive(true);
        }
    }
}
