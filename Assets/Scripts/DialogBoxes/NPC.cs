
using UnityEngine;

public class NPC : Sing
{
    public DialogueManager dialogueManager;
    
    public Dialogue dialogue;

    private void Update()
    {
        DoDialogue();
    }

    public void DoDialogue()
    {
        if (playerInRange)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (dialogBox.activeInHierarchy)
                {
                    dialogBox.SetActive(false);
                }
                else
                {
                    dialogBox.SetActive(true);
                    TriggerDialogue();
                }
            }
        }
    }
    public void TriggerDialogue()
    {
        dialogueManager.StartDialogue(dialogue);
    }
}
