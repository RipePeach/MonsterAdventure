using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QustSteps : MonoBehaviour
{
    [TextArea(5, 10)]
    public string dialogueBox;

    public QustSteps[] questSteps;

    public bool questIsComplited;
}
