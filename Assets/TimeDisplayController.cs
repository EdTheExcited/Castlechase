using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeDisplayController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        float minutes = Mathf.FloorToInt(worldCollisions.endTime / 60);
        float seconds = Mathf.FloorToInt(worldCollisions.endTime % 60);

        GetComponent<Text>().text = string.Format("{0:00}:{1:00}", minutes, seconds);

        // GetComponent<Text>().text = worldCollisions.endTime.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
