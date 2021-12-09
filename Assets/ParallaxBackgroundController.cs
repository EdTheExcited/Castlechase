using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackgroundController : MonoBehaviour
{

    [SerializeField]
    Transform playerTransform;

    Vector3 offset = new Vector3();

    [SerializeField]
    float multiplier = 1;

    // Start is called before the first frame update
    void Start()
    {
        offset = playerTransform.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = (playerTransform.position + offset) * multiplier;
    }
}
