using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlayerInventory PI;

    private void Awake()
    {
        PI = FindObjectOfType<PlayerInventory>();
    }

    public Dictionary<int, int> plantingZones = new Dictionary<int, int>()
    {
        {1, -1},
        {2, -1},
        {3, -1},
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

    public GameObject[] cacti;
    public GameObject[] items;

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
            plantingZones[plantZone.plantZoneNum] = plantZone.plantType;
        }
    }


}
