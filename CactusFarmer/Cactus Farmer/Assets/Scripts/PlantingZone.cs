using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantingZone : MonoBehaviour
{
    //where to spawn plant
    public Transform plantSpawn;
    //which planting zone this is
    public int plantZoneNum;    
    //number indicates which plant is here
    public int plantType;
    /*
       -1 - no plant
       0 - purple flower cactus

     */


    public GameManager GM;
    private void Awake()
    {
        GM = FindObjectOfType<GameManager>();
        
    }
    void Start()
    {
        plantType = GM.plantingZones[plantZoneNum][0];
        
        if (plantType != -1)
        {
            Instantiate(GM.cacti[plantType], plantSpawn);
            GetComponentInChildren<Cactus>().growthStage = GM.plantingZones[plantZoneNum][1];
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
