using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class CollectableItems : MonoBehaviour
{
   
    string tagName;
   
    private TextMeshProUGUI info_subtext;
    public Sprite sprite;

    void Start()
    {
        tagName = gameObject.tag;
        
        /*
        TextMeshProUGUI[] tmps;
        tmps = GameObject.FindObjectsOfType<TextMeshProUGUI>();
        info_subtext = tmps.Where(tmp => tmp.tag == "info_subtext").ToArray()[0];
        */
        

    }

    // Update is called once per frame
    void Update()
    {
        

       

        //burasý toplanabilir bir neseneye bakýyorsa
        if (SelectionManager.instance.getHit().collider != null && SelectionManager.instance.getHit().collider.gameObject == gameObject)
        {
           // info_subtext.text = "press e to collect";
  
            SelectionManager.instance.setCrosshairTextSubtext(sprite,tagName.ToLower(), "press e to collect");

            Debug.Log("press e to collect");
            if (Input.GetKey(KeyCode.E))
            {
                
                 if (!Inventory.Instance.CheckIfFull())
                 {
                     Inventory.Instance.AddToInventory(tagName);

                     Debug.Log(tagName + " envanterdsdse alndý");

                     // envantere ekleme sistemi yeri

                     Destroy(gameObject);
                 }
                 else
                 {
                     Debug.Log("Inventory is full");
                 }

            }



        }
        

        
        
       
    

    }
 

}
