using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCollDetector : MonoBehaviour
{
    public GameObject player;

    

    private void Update()
    {
        float dist = Vector3.Distance(transform.position, player.transform.position);
        if (dist < 5)
        {
            PlayerState.instance.isPlayerNearToFire = true;
        }
        else
        {
            PlayerState.instance.isPlayerNearToFire = false;
        }
    }
}
