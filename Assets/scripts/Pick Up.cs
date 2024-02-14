using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObjTrigger : MonoBehaviour
{
    


// object 1 that appeares
    public GameObject ColectedObj;
// object 2 that appeares
    public GameObject TriggerObj;
//object that dissapeares
    public GameObject DeletedObj;
    public GameObject Tutorialtxt;
    public GameObject Tutorialtxt2;


    void Start()
    {
        ColectedObj.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "player")
        {
            if (Input.GetKey(KeyCode.E))
            {
                // hides and deactivates the interaced object
                this.gameObject.SetActive(false);
                // deaactivates the DeleatedObj object
                DeletedObj.SetActive(false);

                Tutorialtxt.SetActive(false);
                //activates object 1
                ColectedObj.SetActive(true);
                //activates object 
                TriggerObj.SetActive(true);

                Tutorialtxt2.SetActive(true);
                
            }
        }
    }
}
