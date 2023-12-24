using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCollDetector1 : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "fire")
        {

            Debug.Log("PlayerBody collided with an object tagged as 'Fire'.");
            PlayerState.instance.isPlayerNearToFire = true;


        }
    }
}
