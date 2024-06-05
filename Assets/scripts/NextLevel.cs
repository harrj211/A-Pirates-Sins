using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay(Collision collision)
    {
        if(tag == "NextLevel")
        {
            SceneManager.UnloadSceneAsync (sceneName:"Prison");
            SceneManager.LoadScene (sceneName:"Title");
        }
    }
}
