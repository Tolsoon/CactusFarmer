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

    public GameManager GM;

    private void Awake()
    {
        GM = FindObjectOfType<GameManager>();        

    }
    void Start()
    {
        
        for(int i = 0; i < inventory.Length; i++)
        {
            inventory[i].GetComponent<Item>().itemKey = GM.inventoryItems[i][0];
            inventory[i].GetComponent<Item>().amount = GM.inventoryItems[i][1];
            inventory[i].GetComponent<Item>().sellValue = GM.inventoryItems[i][2];
            inventory[i].GetComponent<Item>().setSprite();
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

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == ("item"))
        {
            pickupItem(hit.gameObject);
        }
    }


    void pickupItem(GameObject pickup)    
    {        
        for (int i = 0; i < inventory.Length; i++)
        {
            if(inventory[i].GetComponent<Item>().itemKey == pickup.GetComponent<Item>().itemKey)
            {
                setItemValues(pickup.GetComponent<Item>(), i);
                Destroy(pickup);
                break;
            }
            else if (inventory[i].GetComponent<Item>().itemKey == 0)
            {
                setItemValues(pickup.GetComponent<Item>(), i);                
                Destroy(pickup);               
                break;
            }
        }
    }

    //sets the correct values in the correct inventory slot
    //also sets the values for the GM saver
    void setItemValues(Item item, int i)
    {       
        inventory[i].GetComponent<Item>().sellValue = item.sellValue;        
        inventory[i].GetComponent<Item>().itemKey = item.itemKey;
        inventory[i].GetComponent<Item>().sprite = item.sprite;
        inventory[i].GetComponent<Item>().amount += 1;
        inventorySprites[i].sprite = item.sprite;

        GM.inventoryItems[i] = new int[] { item.itemKey, item.amount, item.sellValue }; 

    }
}
