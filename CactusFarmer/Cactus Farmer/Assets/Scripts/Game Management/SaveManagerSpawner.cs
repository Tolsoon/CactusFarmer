using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManagerSpawner : MonoBehaviour
{
    public GameObject saver;
    private void Awake()
    {
        if(FindObjectOfType<Saver>() == null)
        {
            Instantiate(saver);
        }
        else
        {
            saver.GetComponent<Saver>().LoadSave();
        }
    }
}
