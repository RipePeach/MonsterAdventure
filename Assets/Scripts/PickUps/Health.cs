using System.Collections;
using Interfaces;
using UnityEngine;

public class Health : PickUp, IDoEffect
{
    [SerializeField] private int addHeart;
    [SerializeField] private GameObject pickUpEffect;

    private int dilay = 1;
    private HeartsManager _heartsManager;

    private void Start()
    {
        _heartsManager = FindObjectOfType<HeartsManager>();
    }

    public override void Apply(CharacterScript player)
    {
        if (player.health + addHeart >= player.maxHealth)
        {
            player.health = player.maxHealth;
            CreateEffect();
            Destroy(gameObject);
        }
        else
        {
            player.health += addHeart;
            CreateEffect();
            Destroy(gameObject);
        }

        _heartsManager.ChangeHearts();
    }

    public void CreateEffect()
    {
        if (pickUpEffect != null)
        {
            var transform1 = transform;
            Vector3 effectPosition = transform1.position;
            Instantiate(pickUpEffect, effectPosition, transform1.rotation);
        }
    }
}