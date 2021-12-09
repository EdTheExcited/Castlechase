using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class worldCollisions : MonoBehaviour
{
    public static float endTime;

    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            endTime = Timer.instance.timeValueMax - Timer.instance.timeValue;


        }
    }
}
