using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    public GameObject[] inventory;
    public Image[] inventorySprites;
    public GameObject[] bgs;

    public Item selectedItem;
    public int mouseScroll;
    void Start()
    {
        for(int i = 0; i < inventorySprites.Length; i++)
        {
            inventorySprites[i].sprite = inventory[i].GetComponent<Item>().sprite;
        }

        selectedItem = inventory[0].GetComponent<Item>();
        bgs[0].SetActive(true);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {            
            bgs[mouseScroll].SetActive(false);
            mouseScroll += 1;           
            if (mouseScroll > 7)
            {
                mouseScroll = 0;
            }
            bgs[mouseScroll].SetActive(true);
            selectedItem = inventory[mouseScroll].GetComponent<Item>();
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {            
            bgs[mouseScroll].SetActive(false);
            mouseScroll -= 1;
            if (mouseScroll < 0)
            {
                mouseScroll = 7;
            }
            bgs[mouseScroll].SetActive(true);
            selectedItem = inventory[mouseScroll].GetComponent<Item>();
        }

        
    }
}
