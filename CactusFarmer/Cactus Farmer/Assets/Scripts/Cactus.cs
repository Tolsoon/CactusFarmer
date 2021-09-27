using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cactus : MonoBehaviour
{
    //string indicating what type of plant is here
    public int plantType;
    public int growthStage;
    public int harvestStage;
    public GameObject flower;


    /*
        0 - Purple Flower Cactus
        1 - Red Flower Cactus
        2 - Blue Flower Cactus
        3 - Orange Flower Cactus

     
     */

    private void Start()
    {
        transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
    }

    public void CheckGrowth()
    {
        if (growthStage >= harvestStage)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if (growthStage >= harvestStage / 2)
        {
            transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }
    }

}
