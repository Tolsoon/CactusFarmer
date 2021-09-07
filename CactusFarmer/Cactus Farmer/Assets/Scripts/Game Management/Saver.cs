using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Saver : MonoBehaviour
{
    GameManager GM;
   
    private void Awake()
    {
        SaveSystem.Init();
        DontDestroyOnLoad(gameObject);
        GM = FindObjectOfType<GameManager>();

        LoadSave();
    }

    
    public void Save()
    {


        //converts dictionarys into json file seperated by "n" so that it can be split later
        string json = JsonConvert.SerializeObject(GM.plantingZones, Formatting.Indented) + "n" + JsonConvert.SerializeObject(GM.inventoryItems, Formatting.Indented) + "n";
        SaveSystem.Save(json);
        //debug line if you need to view saved json file
        Debug.Log(json);
    }

    public void LoadSave()
    {
        string saveString = SaveSystem.Load();
        string[] splits = saveString.Split('n');

        //seperate dictionary strings and convert them back into dictionaries
        Dictionary<int, int> plantingZones  = JsonConvert.DeserializeObject<Dictionary<int, int>>(splits[0]);
        Dictionary<int, int[]> inventoryItems = JsonConvert.DeserializeObject<Dictionary<int, int[]>>(splits[1]);
        Debug.Log(splits[0]);
        Debug.Log(splits[1]);
        //take dictionaries from save data and put them into game data
        GM.plantingZones = plantingZones;
        GM.inventoryItems = inventoryItems;
        

    }

    public void DeleteSaves()
    {

        SaveSystem.DeleteSaves();
        Debug.Log("Deleted Saves");
    }

    

}
