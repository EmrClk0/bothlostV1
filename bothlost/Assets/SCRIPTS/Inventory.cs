using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance { get; set; }

    public GameObject inventoryScreenUI;

    public List<GameObject> slotList = new List<GameObject>();

    public List<string> itemList = new List<string>();

    private GameObject itemToAdd;

    private GameObject whatSlotToEquip;

    public bool isOpen;

   // public bool isFull;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    void Start()
    {
        isOpen = false;
       
        PopulateSlotList();

    }

    private void PopulateSlotList()
    {
        foreach (Transform child in inventoryScreenUI.transform)
        {
            if(child.CompareTag("Slot"))
            {
                slotList.Add(child.gameObject);
            }
            
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I) && !isOpen)
        {
            Debug.Log("i is pressed");
            inventoryScreenUI.SetActive(true);
            isOpen = true;
        }
        else if (Input.GetKeyDown(KeyCode.I) && isOpen)
        {
            inventoryScreenUI.SetActive(false);
            isOpen = false;
        }
    }


    public void AddToInventory(string itemName)
    {
        
    
      whatSlotToEquip = FindNextEmptySlot();

      itemToAdd = (GameObject)Instantiate(Resources.Load<GameObject>(itemName), whatSlotToEquip.transform.position,whatSlotToEquip.transform.rotation);
      itemToAdd.transform.SetParent(whatSlotToEquip.transform);

      itemList.Add(itemName);


        

    }

    private GameObject FindNextEmptySlot()
    {
        foreach (GameObject slot in slotList)
        {
            if(slot.transform.childCount==0)
            {
                return slot;
            }
           
        }
        return new GameObject();
    }

    public bool CheckIfFull()
    {
        int counter = 0;

        foreach (GameObject slot in slotList)
        {
            if(slot.transform.childCount>0)
            {

                counter += 1;
            }
            
        }

        if (counter == 24) 
        { 
            return true;
        }
        else { return false; }


    }




}
