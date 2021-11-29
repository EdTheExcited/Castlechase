
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField]
    GameObject player;

    Vector3 offset;

    private void Start()
    {
        offset = player.transform.position - this.transform.position;
    }

    private void Update()
    {

        Vector3 pos = this.transform.position;

        pos.x = player.transform.position.x - offset.x;
        pos.y = player.transform.position.y - offset.y;

        this.transform.position = pos;

        // this.transform.position = new Vector3(
        //     player.transform.position.x,
        //     this.transform.position.y,
        //     this.transform
        // );

        // this.transform.position = player.transform.position - offset;
    }



    // [SerialzeField] private float speed;
    // private float currentPosX;
    // private Vector3 velocity = Vector3.zero;

    // private void Update(){
    //     // transform.position= Vector3.SmoothDamp(transform.position, new Vector3(currentPosX, transform.position.y, transform.position.z), velocity, speed * Time.deltaTime);

    // }
}

