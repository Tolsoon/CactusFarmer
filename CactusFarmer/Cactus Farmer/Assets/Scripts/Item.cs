using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int sellValue;
    public int itemKey;
    public Sprite sprite;
    public int amount;

    public Sprite[] sprites;

    


    /*item keys
    0 - Empty Item
    1 - Regular Cactus Seed
    2 - Regular Cactus Flower
      
    */

    public void setSprite()
    {
        sprite = sprites[itemKey];
    }


}
