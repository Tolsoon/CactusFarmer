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

    GameManager GM;
    private void Awake()
    {
        GM = FindObjectOfType<GameManager>();
        plantType = GM.plantingZones[plantZoneNum];
    }
    void Start()
    {
        if(plantType != -1)
        {
            Instantiate(GM.cacti[plantType], plantSpawn);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}