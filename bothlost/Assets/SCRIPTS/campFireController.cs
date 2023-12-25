using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class campFireController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject stonesAndWoods;
    private GameObject player;
    
    int burningTime;
    bool isFireActive;
    int fireCount;

    private void Start()
    {
        burningTime = 30;
        isFireActive = true;
        player = GameObject.FindGameObjectWithTag("Player");
           
        Invoke("putOutTheFire", burningTime);

       

    }
    



    private void Update()
    {
        /*
        if (isFireActive)
        {
            float dist = Vector3.Distance(transform.position, player.transform.position);
            if (dist < 5) //ateþ yanýyor ve yakýn
            {
                
                 PlayerState.instance.isPlayerNearToFire = true;
            }
            else  //ateþ yanýyor ama uzak
            {

                PlayerState.instance.isPlayerNearToFire = false;
               
                
            }
        }*/

        bool closeOne = isThereAnyCloseFire();
        
        if (closeOne)
        {
            PlayerState.instance.isPlayerNearToFire = true;
        }
        else
        {
            PlayerState.instance.isPlayerNearToFire = false;
        }



    }



    
    void putOutTheFire()
    {
        gameObject.SetActive(false);
        isFireActive = false;
        PlayerState.instance.isPlayerNearToFire = false;
    }

    bool isThereAnyCloseFire()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("campfire");
        foreach (GameObject obj in objs) {
            float dist = Vector3.Distance(obj.transform.position, player.transform.position);
            if (dist < 5) //ateþ yanýyor ve yakýn
            {

                return true;

            }
           
        }
        return false;
    }

    void OnCollisionEnter(Collision collision)
    {
        // Debug-draw all contact points and normals
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("yandýn can azlt");

            // Burada yapmak istediðiniz iþlemleri gerçekleþtirebilirsiniz.
        }
    }


}
