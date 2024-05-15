using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Switch : MonoBehaviour
{
    int title = 1;
    // Update is called once per frame
    void Update()
    {
        if(title == 1 && Input.GetButtonDown("Fire1"))
        {
            SceneManager.UnloadSceneAsync (sceneName:"Title");
            SceneManager.LoadScene (sceneName:"Prison");
            
            title = 0;
        }
    }

}
