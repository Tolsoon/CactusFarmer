using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    //variables need to save
    public int itemKey;
    public int amount;

    //varibles not needed to save
    public int sellValue;    
    public Sprite sprite;
    public bool sellable;
    //whether or not you can plant this
    public bool plantable;
    //what you plant
    public GameObject plantedObj;


    public GameObject thisItem;

    public GameManager GM;




    /*item keys
    0 - Empty Item
    1 - Purple Flower Cactus Seed
    2 - Purple Cactus Flower
      
    */

    private void Awake()
    {
        GM = FindObjectOfType<GameManager>();
    }
    private void Start()
    {
        Item tempItem = thisItem.GetComponent<Item>();
        sellValue = tempItem.sellValue;
        sprite = tempItem.sprite;
        plantable = tempItem.plantable;
        plantedObj = tempItem.plantedObj;
        sellable = tempItem.sellable;

    }

    public void setSprite()
    {
        sprite = GM.items[itemKey].GetComponent<Item>().sprite;

    }

    public void SetToEmpty()
    {
        sellValue = 0;
        itemKey = 0;
        sprite = GM.items[itemKey].GetComponent<Item>().sprite;
        amount = 0;
        plantable = false;
        thisItem = GM.items[itemKey];
        plantedObj = null;
        sellable = false;
    }

    


}
