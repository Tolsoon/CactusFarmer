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

    public bool canSell;

    public bool canBuy;
    public GameObject buyMenu;

    public int money;
    public Text moneyText;

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
            inventory[i].GetComponent<Item>().thisItem = inventory[i].GetComponent<Item>().items[inventory[i].GetComponent<Item>().itemKey];
            inventorySprites[i].sprite = inventory[i].GetComponent<Item>().sprites[inventory[i].GetComponent<Item>().itemKey];
            inventorySprites[i].GetComponentInChildren<Text>().text = inventory[i].GetComponent<Item>().amount.ToString();

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

        if(selectedItem.itemKey != -1)
        {
            if (Input.GetKeyDown(KeyCode.E) && canSell && selectedItem.sellable)
            {
                
                money += selectedItem.sellValue;
                moneyText.text = "Money: " + money.ToString();
                selectedItem.amount -= 1;
                inventorySprites[mouseScroll].GetComponentInChildren<Text>().text = inventory[mouseScroll].GetComponent<Item>().amount.ToString();
                if (selectedItem.amount <= 0)
                {
                    selectedItem.SetToEmpty();
                    UpdateSelectedItems();
                }
            }
        }

        

        
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("item"))
        {
            pickupItem(hit.gameObject);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("sellZone"))
        {            
            canSell = true;
        }

        if (other.gameObject.CompareTag("buyZone"))
        {
            canBuy = true;
            buyMenu.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("sellZone"))
        {
            canSell = false;
        }

        if (other.gameObject.CompareTag("buyZone"))
        {
            canBuy = false;
            buyMenu.SetActive(false);
        }
    }




   void pickupItem(GameObject pickup)    
    {
        int a = 0;

        for (int i = 0; i < inventory.Length; i++)
        {            
            if (inventory[i].GetComponent<Item>().itemKey == pickup.GetComponent<Item>().itemKey)
            {
                setItemValues(pickup.GetComponent<Item>(), i);
                Destroy(pickup);
                break;
            }
            else
            {
                a += 1;
            }

            if(a == inventory.Length)
            {
                for (int c = 0; c < inventory.Length; c++)
                {
                    if (inventory[c].GetComponent<Item>().itemKey == 0)
                    {
                        setItemValues(pickup.GetComponent<Item>(), c);
                        Destroy(pickup);
                        break;
                    }
                }
                
            }
            
        }
    }

    //sets the correct values in the correct inventory slot
    
    public void setItemValues(Item item, int i)
    {         
        inventory[i].GetComponent<Item>().sellValue = item.sellValue; 
        
        inventory[i].GetComponent<Item>().itemKey = item.itemKey;

        inventory[i].GetComponent<Item>().sprite = item.sprite;

        inventory[i].GetComponent<Item>().amount += 1;

        inventory[i].GetComponent<Item>().plantable = item.plantable;

        inventory[i].GetComponent<Item>().plantedObj = item.plantedObj;

        inventory[i].GetComponent<Item>().sellable = item.sellable;

        inventorySprites[i].sprite = item.sprite;

        inventory[i].GetComponent<Item>().thisItem = item.items[item.itemKey];

        inventorySprites[i].GetComponentInChildren<Text>().text = inventory[i].GetComponent<Item>().amount.ToString();
        
    }


    public void buyItem(Item item)
    {
        int a = 0;

        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i].GetComponent<Item>().itemKey == item.itemKey)
            {
                setItemValues(item.GetComponent<Item>(), i);
               
                break;
            }
            else
            {
                a += 1;
            }

            if (a == inventory.Length)
            {
                for (int c = 0; c < inventory.Length; c++)
                {
                    if (inventory[c].GetComponent<Item>().itemKey == 0)
                    {
                        setItemValues(item.GetComponent<Item>(), c);
                        
                        break;
                    }
                }

            }

        }
    }
    //update inventory bar sprites
    public void UpdateSelectedItems()
    {
        for (int i = 0; i < inventory.Length; i++)
        {
            if(inventory[i].GetComponent<Item>().amount <= 0)
            {
                inventorySprites[i].sprite = inventory[i].GetComponent<Item>().sprite;
                inventorySprites[i].GetComponentInChildren<Text>().text = inventory[i].GetComponent<Item>().amount.ToString();
            }
        }
    }

}
