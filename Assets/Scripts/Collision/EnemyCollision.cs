using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyCollision : MonoBehaviour

{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            MovementScirpt movementScirpt = other.gameObject.GetComponent<MovementScirpt>();
            if (movementScirpt)
            {
                movementScirpt.Reset();
            }



        }
    }

    void Update()
    {

    }
}
