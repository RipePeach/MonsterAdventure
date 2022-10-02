using UnityEngine;

public class Abyss : PortalBetweenPoints
{
    [SerializeField] private bool dangerousBlock;

    [Header("CheckPLayer")] [SerializeField]
    private LayerMask platform;

    [SerializeField] private float platformInRadius = 1f;
    [SerializeField] private int damage;
    private Animator _animator;

    public override void Apply(Collider2D other)
    {
        RaycastHit2D hit1 = Physics2D.Raycast(other.transform.position, Vector2.down, platformInRadius, platform);
        if (other.GetComponent<CharacterScript>() && dangerousBlock && hit1.collider == null)
        {
            other.GetComponentInChildren<Animator>().SetTrigger("SwitchOff/On");
            CharacterScript characterScript = other.GetComponent<CharacterScript>();
            if (characterScript != null)
            {
                characterScript.GetDamage(damage);
                TeleportWithEffect(other);
            }
        }
    }
}