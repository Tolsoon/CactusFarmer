using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlayerInventory PI;
    public int day;
    public float dayTime;

    public GameObject[] cacti;

    //array of all items that are purchasable in shop
    public GameObject[] purchaseItems;
    //array of all items in game
    public GameObject[] items;
    

    /*
     0 - purple flower cactus seed
     */
    private void Awake()
    {
        PI = FindObjectOfType<PlayerInventory>();
        day = varSaved[0];
    }

    //first number is which planting zone, second number is what is planted, third is the growth stage
    public Dictionary<int, int[]> plantingZones = new Dictionary<int, int[]>()
    {
        {1, new int[] {-1,0}},
        {2, new int[] {-1,0}},
        {3, new int[] {-1,0}},
    };

    //dictionary of items in inventory, the fist number is the itemKey the second is the quantity, third is sell value,
    public Dictionary<int, int[]> inventoryItems = new Dictionary<int, int[]>()
    {
        {0, new int[] {0,0,0}},
        {1, new int[] {0,0,0}},
        {2, new int[] {0,0,0}},
        {3, new int[] {0,0,0}},
        {4, new int[] {0,0,0}},
        {5, new int[] {0,0,0}},
        {6, new int[] {0,0,0}},
        {7, new int[] {0,0,0}},
    };

    //dictionary of varibles that need to be saved: first is the day, second is player money
    public Dictionary<int, int> varSaved = new Dictionary<int, int>()
    {
        {0, 0},
        {1, 0},
        
    };

    

    public void UpdateDicts()
    {
        for(int i = 0; i < PI.inventory.Length;i++)
        {
            inventoryItems[i] = new int[] 
            { 
                PI.inventory[i].GetComponent<Item>().itemKey, 
                PI.inventory[i].GetComponent<Item>().amount, 
                PI.inventory[i].GetComponent<Item>().sellValue
            };
        }

        var plantZones = FindObjectsOfType<PlantingZone>();

        foreach(PlantingZone plantZone in plantZones)
        {
            if(plantZone.plantType != -1)
            {
                plantingZones[plantZone.plantZoneNum] = new int[] { plantZone.plantType, plantZone.gameObject.GetComponentInChildren<Cactus>().growthStage};
            }
            
        }

        varSaved[0] = day;
        varSaved[1] = PI.money;
    }

    public void BuyItem(Item item)
    {
        if(PI.money >= Mathf.RoundToInt(item.sellValue * 1.2f))
        {
            PI.buyItem(item);
            PI.money -= Mathf.RoundToInt(item.sellValue * 1.2f);
            PI.moneyText.text = "Money: " + PI.money.ToString();
        }
    }


}
