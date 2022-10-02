using System;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Movement : MonoBehaviour
{
    private const string MOVEX = "MoveX";
    private const string MOVEY = "MoveY";
    private static readonly int MoveX = Animator.StringToHash(MOVEX);
    private static readonly int MoveY = Animator.StringToHash(MOVEY);
    
    public float speed;
    public Animator Animator { get; private set; }
    public Rigidbody2D Rigidbody2D { get; private set; }
    public bool CanMove { get; set; }
    public CharacterScript Character { get; private set; }
    
    private Monster _monster;

    private void Awake()
    {
        Character = FindObjectOfType<CharacterScript>();
        _monster = FindObjectOfType<Monster>();
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Animator = GetComponentInChildren<Animator>();
        CanMove = true;
        StartAdditional();
    }

    protected virtual void StartAdditional()
    {
        
    }

    protected virtual void Update()
    {
        ApplyAnimation();
    }

     protected virtual void FixedUpdate()
     {
         Move(); 
         FUpdate();
     }

     protected virtual void FUpdate()
     {
         
     }
    
    public virtual void ApplyAnimation()
    {
        if (Rigidbody2D != null)
        {
            Animator.SetFloat(MoveX, Rigidbody2D.velocity.x); 
            Animator.SetFloat(MoveY, Rigidbody2D.velocity.y);
        }
    }

    //двигаем твердое тело
    public void Move()
    {
        if (CanMove && Rigidbody2D != null)
        {
            Rigidbody2D.velocity = Direction().normalized * (speed * Time.deltaTime);
        }
    }

    protected virtual Vector3 Direction()
    {
        return Vector3.zero;
    }
    
    public void StopMovement()
    {
        if (Rigidbody2D != null)
        {
            Rigidbody2D.velocity = Vector3.zero;
            Rigidbody2D.Sleep();
            CanMove = false;
        }
    }
    
    public void StartMovement()
    {
        if (Rigidbody2D != null)
        {
            Rigidbody2D.WakeUp();
            CanMove = true;
        }
    }
}
