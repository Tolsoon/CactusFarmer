using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPlanting : MonoBehaviour
{
    public bool canPlant;

    public PlantingZone plantingZone;
    public PlayerInventory playerInventory;
    GameManager GM;
    void Start()
    {
        GM = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && canPlant)
        {
            Instantiate(playerInventory.selectedItem.plantedObj, plantingZone.plantSpawn);
            plantingZone.plantType = plantingZone.GetComponentInChildren<Cactus>().plantType;
            playerInventory.selectedItem.amount -= 1;

            playerInventory.inventorySprites[playerInventory.mouseScroll].GetComponentInChildren<Text>().text 
                = playerInventory.selectedItem.GetComponent<Item>().amount.ToString();

            if(playerInventory.selectedItem.amount <= 0)
            {
                playerInventory.selectedItem.SetToEmpty();
                playerInventory.UpdateSelectedItems();
            }
            canPlant = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("plantZone"))
        {
            plantingZone = other.GetComponent<PlantingZone>();
            if(plantingZone.plantSpawn.childCount > 1 || !playerInventory.selectedItem.plantable)
            {
                canPlant = false;
            }
            else
            {
                canPlant = true;
            }
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("plantZone"))
        {
            plantingZone = null;
        }
    }
}
