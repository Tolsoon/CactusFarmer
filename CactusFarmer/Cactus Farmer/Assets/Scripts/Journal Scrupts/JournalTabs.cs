using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JournalTabs : MonoBehaviour
{
    public GameObject JournalEntries;
    public GameObject CodexEntries;
    public GameObject LocationEntries;

    public void SetJournalActive()
    {
        JournalEntries.SetActive(true);
        CodexEntries.SetActive(false);
        LocationEntries.SetActive(false);
    }

    public void SetCodexActive()
    {
        JournalEntries.SetActive(false);
        CodexEntries.SetActive(true);
        LocationEntries.SetActive(false);
    }

    public void SetLocationActive()
    {
        JournalEntries.SetActive(false);
        CodexEntries.SetActive(false);
        LocationEntries.SetActive(true);
    }
}
