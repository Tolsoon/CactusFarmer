using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Dictionary<int, int> plantingZones = new Dictionary<int, int>()
    {
        {1, -1},
        {2, -1},
        {3, -1},
    };

    public GameObject[] cacti;
    public GameObject[] items;


}
