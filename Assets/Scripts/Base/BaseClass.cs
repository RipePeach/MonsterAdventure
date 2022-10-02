using System;
using Lean.Pool;
using UnityEngine;


public class BaseClass : MonoBehaviour
{
    [Header("Config parameters")]
    [SerializeField] public int health;
    [SerializeField] public int maxHealth;
    [SerializeField] public int damage;
    [SerializeField] protected internal float attackRadius;
    //кому может наноситься урон
    [SerializeField] protected internal LayerMask selectObjectsToHit;
    //ледяная глыба, наносит урон
    [SerializeField] protected GameObject iceCube;
    [SerializeField] protected MusicManager musicManager;
    
   
    public Action onDeath = delegate {  };

    public Action onHealthChanged = delegate {  };

    private static readonly int Death1 = Animator.StringToHash("Death");
    private static readonly int LastMoveX = Animator.StringToHash("LastMoveX");
    private static readonly int LastMoveY = Animator.StringToHash("LastMoveY");

    public Rigidbody2D Rigidbody2D { get; set; }
    public Collider2D Collider2D { get; set; }
    public Animator Animator { get; set; }
    public Movement Movement { get; set; }
    public CharacterScript CharacterScript { get; private set; }
    public EnemyScript EnemyScript { get; set; }
    public AnimationHelper AnimationHelper { get; set; }

    public bool Frozen { get; set; }

    private void Awake()
    {
        Animator = GetComponentInChildren<Animator>();
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Collider2D = GetComponent<Collider2D>();
        Movement = GetComponent<Movement>();
        CharacterScript = GetComponent<CharacterScript>();
        EnemyScript = GetComponent<EnemyScript>();
        musicManager = FindObjectOfType<MusicManager>();
        AnimationHelper = GetComponent<AnimationHelper>();
    }

    private void Start()
    {
        StartAdditional();
        Frozen = false;
    }

    protected virtual void StartAdditional()
    {
        
    }

    /// <summary>
    /// gameObject получает урон 
    /// </summary>
    /// <param name="getDamage"></param>
    public void GetDamage(int getDamage)
    {
        if (health != 0)
        {
            health -= getDamage;
            onHealthChanged();
        }

        if (health <= 0)
        {
            Death();
        }
    }

    protected virtual void Death()
    {
        //анимация срабатывает по триггеру
        Animator.SetTrigger(Death1);
        onDeath?.Invoke();
        Destroy(Movement);
        Destroy(Rigidbody2D);
        //Destroy(Collider2D);
        DeathAdditional();
    }

    protected virtual void DeathAdditional()
    {
        
    }

    //создать лед в позиции игрока

    public virtual void Freeze()
    {
        if (iceCube != null && !Frozen)
        {
            LeanPool.Spawn(iceCube, transform);
            Frozen = true;
        }
    }

    public virtual Vector2 GetAttackDirection()
    {
        float x = Animator.GetFloat(LastMoveX);
        float y = Animator.GetFloat(LastMoveY);
        if (x == 1 && y == 0 )
        {
            return Vector2.right;
        }
        if (x == -1 && y == 0)
        {
            return Vector2.left;
        }
        if (y == 1)
        {
            return Vector2.up;
        }
        if (y == -1)
        {
            return Vector2.down;
        }
        return Vector2.down;
    }
}
