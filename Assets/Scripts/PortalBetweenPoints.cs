using System;
using UnityEngine;
using DG.Tweening;
using Lean.Pool;
public class PortalBetweenPoints : MonoBehaviour
{
    //куда телепортация
    [SerializeField] Transform destinationPoint;
    [SerializeField] private ParticleSystem portalEffect;

    private void OnTriggerStay2D(Collider2D collision)
    {
        Apply(collision);
    }

    public virtual void Apply(Collider2D collision)
    {
        TeleportWithEffect(collision);
    }

    public void TeleportWithEffect(Collider2D collision)
    {
        Sequence sequence = DOTween.Sequence();
        Vector2 position = collision.transform.position;
        sequence.AppendCallback(() => Teleport(collision));
        sequence.AppendCallback(() => PortalEffect(position));
    }
    void Teleport(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out CharacterScript characterScript))
        {
            characterScript.transform.position = destinationPoint.position;
        }
    }

    private void PortalEffect(Vector2 position)
    {
        if (portalEffect != null)
        {
            Vector3 portalEffectPosition = position;
            LeanPool.Spawn(portalEffect, portalEffectPosition, transform.rotation);
        }
    }
}
