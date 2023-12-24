using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.Linq;
using UnityEngine.UI;

public class SelectionManager : MonoBehaviour
{
    public Transform playerCamera;  // Kamera referansý
    public TextMeshProUGUI displayText;
    public TextMeshProUGUI info_subtext;

    public Image crosshair;
    private string[] allowedHitTags = { "tree", "rock" , "branch","rabbitmeat","rabbit" };

    private bool onTarget;
    private RaycastHit hit;
    public static SelectionManager instance { get; set; }
    private Sprite mainSprite;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        onTarget = false;
        
        mainSprite = crosshair.sprite;
    }


    void Update()
    {
        Ray ray = new Ray(playerCamera.position, playerCamera.forward);
        
        //üzerine gelince ekranda info
        if (Physics.Raycast(ray, out hit, 5.0f) && allowedHitTags.Contains(hit.collider.tag.ToString()))
        {
            
            string tagName = hit.collider.tag.ToString().ToLower();

            displayText.text = tagName.ToString();
            
            onTarget = true;

            
            
            
        }
        else
        {
            displayText.text = "";
            info_subtext.text = "";
            crosshair.sprite = mainSprite;
            onTarget = false;
           
        }
    }

    public RaycastHit getHit()
    {
        return this.hit;
    }


    public bool getOnTarget()
    {
        return onTarget;
    }

    public void setCrosshairTextSubtext(Sprite sprite, String mainText, String subText)
    {
        crosshair.sprite = sprite;
        displayText.text = mainText;
        info_subtext.text = subText;

    }


   public void setCrosshairTextSubtext( String mainText, String subText)
    {
        displayText.text = mainText;
        info_subtext.text = subText;
    }



}
