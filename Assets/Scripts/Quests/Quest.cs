
using UnityEngine;
using UnityEngine.UI;

public class Quest : MonoBehaviour
{
    [Header("Elements")]
    public Text contentText; 
    public QustSteps activeStep; // степ, выводящийся на экран в данный момент
    private QuestManager questsProgress;
    
    void ResetGame(QustSteps step)
    {
        contentText.text = step.dialogueBox;
        
    }
    
    //todo
    void Start()
    {
        ResetGame(activeStep);
    }
}
