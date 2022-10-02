using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager
{
    private bool questNotStarted;
    private bool questInProgress;
    private bool questIsComplited;
    
    // todo
    void Start()
    {
        questNotStarted = false;
        questInProgress = false;
        questIsComplited = false;
    }
}
