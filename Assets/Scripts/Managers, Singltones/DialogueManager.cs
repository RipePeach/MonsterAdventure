using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DialogueManager : MonoBehaviour
{
    #region Singletone

    public static DialogueManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject); 
        }
        else
        {
            Instance = this;
        }
    }

    #endregion

    public Text nameText;
    public Text dialogueText;

    public Animator _animator;

    // массив предложений диалога
    private Queue<string> sentences;
    private static readonly int IsOpen = Animator.StringToHash("isOpen");

    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        _animator.SetBool(IsOpen, true);
        nameText.text = dialogue.name;
        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

   public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
       
        StartCoroutine(TypeSentence(sentence));
        var coroutine = TypeSentence(sentence);
        StopCoroutine(coroutine);
    }

   //печать по буквам
   IEnumerator TypeSentence(string sentence)
   {
       dialogueText.text = "";
       foreach (char letter in sentence)
       {
           dialogueText.text += letter;
           yield return null;
       }
   }

   //Анимация закрытия диалога
   public void EndDialogue()
    {
        _animator.SetBool(IsOpen, false);
    }
}
