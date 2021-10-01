using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Codex : MonoBehaviour
{
    int codexNum;
    GameManager GM;

    private void Start()
    {
        GM = FindObjectOfType<GameManager>();
    }
}
