using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OutOfBounds : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            // Scene Level = SceneManager.GetActiveScene();
            // SceneManager.LoadScene(Level.name);
            MovementScirpt movementScirpt = other.gameObject.GetComponent<MovementScirpt>();
            if (movementScirpt)
            {
                movementScirpt.Reset();
            }
        }

        else if (other.gameObject.tag == "King")
        {
            EnemyFollow enemyFollow = other.gameObject.GetComponent<EnemyFollow>();
            if (enemyFollow)
            {
                enemyFollow.Reset();
            }
        }


    }
}
