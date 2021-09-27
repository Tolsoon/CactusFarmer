using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemDisplay : MonoBehaviour
{
    public Text price;
    public Item item;
    public Image displaySprite;
    void Start()
    {
        item = GetComponent<Item>();
        price = GetComponentInChildren<Text>();
        displaySprite = GetComponent<Image>();
        price.text = Mathf.RoundToInt(item.sellValue * 1.2f).ToString();
        displaySprite.sprite = item.sprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
