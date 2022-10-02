using Lean.Pool;
using UnityEngine;

public class AnimationHelper : MonoBehaviour
{
    [SerializeField] private Bullets prefabIceBall;
    [SerializeField] private AudioClip iceSound;
    [SerializeField] protected MusicManager musicManager;

    private Movement _movement;
    private EnemyScript enemyScript;
    public Transform target;

    private void Start()
    {
        musicManager = FindObjectOfType<MusicManager>();
        _movement = GetComponentInParent<Movement>();
        enemyScript = GetComponentInParent<EnemyScript>();
        target = FindObjectOfType<CharacterScript>().transform;
    }

    // монстрик наносит урон плееру в момент анимации атаки
    //Создан Ивент в аниматоре
    public void Attack()
    {
        if (enemyScript != null)
        {
            CharacterScript characterScript = FindObjectOfType<CharacterScript>();
            int enemyDamage = enemyScript.damage;
            characterScript.GetDamage(enemyDamage);
        }
    }

    // создание IceBall в момент анимации Idle
    //Создан Ивент в аниматоре 
    public void CreateIceBall()
    {
        if (enemyScript.canShoot)
        {
            musicManager.PLaySound(iceSound);
            Bullets bullet = LeanPool.Spawn(prefabIceBall, enemyScript.targetPosition.position, transform.rotation);
            bullet.TargetPosition = target.position;
        }
    }

    //Создан ивент в аниматоре
    public void StopMove()
    {
        _movement.StopMovement();
    }

    //Создан ивент в аниматоре
    public void StartMove()
    {
        _movement.StartMovement();
    }
}