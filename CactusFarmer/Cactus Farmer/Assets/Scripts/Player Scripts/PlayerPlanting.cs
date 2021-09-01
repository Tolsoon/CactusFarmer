using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            Instantiate(playerInventory.inventory[0], plantingZone.plantSpawn);
            plantingZone.plantType = plantingZone.GetComponentInChildren<Cactus>().plantType;
            GM.plantingZones[plantingZone.plantZoneNum] = plantingZone.plantType;

            canPlant = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("plantZone"))
        {
            plantingZone = other.GetComponent<PlantingZone>();
            if(plantingZone.plantSpawn.childCount > 1)
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
