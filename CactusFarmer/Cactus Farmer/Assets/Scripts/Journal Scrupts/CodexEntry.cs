using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CodexEntry : MonoBehaviour
{
    public TextMeshProUGUI description;
    public Image picture;
    [TextArea(15, 20)]
    public string desc;

    public void SetEntry()
    {
        picture.sprite = GetComponent<Image>().sprite;
        description.text = desc;
    }

}
