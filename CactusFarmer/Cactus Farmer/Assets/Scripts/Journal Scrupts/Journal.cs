using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Journal : MonoBehaviour
{
    int selectedJournal;
    public GameObject[] journalEntries;

    public void SetSelectedJournal(int select)
    {
        journalEntries[selectedJournal].SetActive(false);
        selectedJournal = select;
        SetActiveJournal();
    }
    public void SetActiveJournal()
    {
        journalEntries[selectedJournal].SetActive(true);

    }
}
