using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class EnemyScript : BaseClass
{
    [SerializeField] public Transform targetPosition;

    [SerializeField] private Text text;
    public bool canShoot = true;
    [Header("Sounds")] 
    [SerializeField] private AudioClip _portalSound;

    private float distance;
    private float meleeAttackDistance;

    [Tooltip("Components")] 
    private CharacterScript _character;

    private Portal _portal;


    private void Update()
    {
        UpdateDistance();
        CheckFreeze();
    }

    public void CreatPortal()
    {
        musicManager.PLaySound(_portalSound);
        Sequence sequence = DOTween.Sequence();
        sequence.AppendInterval(1f);
        // TODO sequence.AppendCallback(() => AudioManager.Instance.PLaySound(portalMusic));
        sequence.AppendCallback(_portal.NextLevelEffect);
        sequence.AppendInterval(1f);
        sequence.AppendCallback(_portal.OnEnablePortal);
    }

    void CheckFreeze()
    {
        if (_character.Frozen)
        {
            canShoot = false;
        }
        else
        {
            canShoot = true;
        }
    }

    void UpdateHpText()
    {
        text.text = "HP: " + health + "/" + maxHealth;
    }

    protected override void StartAdditional()
    {
        _portal = FindObjectOfType<Portal>();
        _character = FindObjectOfType<CharacterScript>();
        Movement = GetComponent<Movement>();
        UpdateHpText();
        onDeath += CreatPortal;
        onHealthChanged += UpdateHpText;
    }

    private void UpdateDistance()
    {
        if (_character != null)
        {
            // Distance to player
            distance = Vector3.Distance(transform.position, _character.transform.position);
            Animator.SetFloat("distance", distance);
        }
    }

    protected override void Death()
    {
        base.Death();
        Destroy(this);
        //после смерти доступна атака ледяной глыбой
        _character.attackType = "Ice";
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        var position = transform.position;
        Gizmos.DrawWireSphere(position, meleeAttackDistance);

        Gizmos.color = Color.magenta;
        Vector3 lookDirection = -transform.up;
        Gizmos.DrawRay(transform.position, lookDirection * meleeAttackDistance);
        Gizmos.color = Color.green;
    }
}