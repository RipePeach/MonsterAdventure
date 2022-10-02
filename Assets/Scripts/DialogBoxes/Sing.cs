using System;
using UnityEngine;
using UnityEngine.UI;

public class Sing : MonoBehaviour
{
    [SerializeField] protected GameObject dialogBox;

    [SerializeField] private Text dialogText;

    [TextArea(2, 10)] [SerializeField] private string dialog;
    protected bool playerInRange;

    private void Update()
    {
        CheckSing();
    }

    void CheckSing()
    {
        if (Input.GetKeyDown(KeyCode.Space) && playerInRange)
        {
            if (dialogBox.activeInHierarchy)
            {
                dialogBox.SetActive(false);
            }
            else
            {
                dialogBox.SetActive(true);
                dialogText.text = dialog;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        CharacterScript character = other.gameObject.GetComponent<CharacterScript>();
        if (character != null)
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        CharacterScript character = other.gameObject.GetComponent<CharacterScript>();
        if (character != null)
        {
            playerInRange = false;
            dialogBox.SetActive(false);
        }
    }
}