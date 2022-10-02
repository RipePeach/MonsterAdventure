using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public Sprite redFlag;
    public Sprite greenFlag;
    private SpriteRenderer checkpointSpriteRenderer;
    public bool checkpointReached;
    
    void Start () 
    {
        checkpointSpriteRenderer = GetComponent<SpriteRenderer> ();
    }
   
    void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.GetComponent<CharacterScript>()) {
            checkpointSpriteRenderer.sprite = greenFlag;
            checkpointReached = true;
        }
    }
}
