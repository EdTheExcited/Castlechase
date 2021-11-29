using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelManagement : MonoBehaviour
{



    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {

            Scene Level = SceneManager.GetActiveScene();
            SceneManager.LoadScene(Level.name);

        }
    }



}
