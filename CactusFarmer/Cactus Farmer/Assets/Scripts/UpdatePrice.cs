using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdatePrice : MonoBehaviour
{
    public Item item;
    public Text priceText;
    void Start()
    {
        item = GetComponentInParent<Item>();
        priceText = GetComponent<Text>();
        priceText.text = Mathf.RoundToInt(item.sellValue * 1.2f).ToString() + " Coins";
    }

}
