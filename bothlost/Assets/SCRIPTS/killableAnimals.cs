using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class killableAnimals : MonoBehaviour
{

    public GameObject meat;
    string tagName;
    // Image handIcon;
    //TextMeshProUGUI infotext;


    void Start()
    {
        tagName = gameObject.tag;
        // GameObject obj = GameObject.FindGameObjectWithTag("info_subtext");
        //infotext = obj.GetComponentInChildren<TextMeshProUGUI>();


    }

    // Update is called once per frame
    void Update()
    {




        //buras� toplanabilir bir neseneye bak�yorsa
        if (SelectionManager.instance.getHit().collider != null && SelectionManager.instance.getHit().collider.gameObject == gameObject)
        {

            
            if (Input.GetMouseButton(0))
            {

                //GetComponent<AI_Movement>().animator.SetBool("isRunning", false);
                GetComponent<AI_Movement>().animator.SetBool("isDied", true);
                Destroy(gameObject);
                Instantiate(meat, transform.position + new Vector3(0, 1, 0), Quaternion.identity);

                Debug.Log(tagName + " �ld�r�ld�");
                //Debug.Log(GetComponent<AI_Movement>().moveSpeed);

                // envantere ekleme sistemi yeri

               
            }


        }

        if (!SelectionManager.instance.getOnTarget())
        {

           // Debug.Log("eski haline d�nd�");
        }




    }


}
