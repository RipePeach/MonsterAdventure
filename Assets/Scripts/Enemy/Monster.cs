using UnityEngine;
using DG.Tweening;
using Interfaces;
using Lean.Pool;
using Random = UnityEngine.Random;

public class Monster : BaseClass, IDoEffect

{
    [SerializeField] private int probability;
    [SerializeField] private GameObject[] pickUps;
    [SerializeField] private GameObject deathMonsterEffect;
    [SerializeField] private int dilay = 1;

    public bool isMonster = true;

    [Tooltip("Components")] 
    
    private Sequence _sequence;

    //todo
    public bool GetMonster()
    {
        return isMonster;
    }

    //todo
    public void SetMonster(bool name)
    {
        isMonster = name;
    }

    //Урон плееру при коллизии
    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent(out CharacterScript character))
        {
            if (character != null)
            {
                character.GetDamage(damage);
            }
        }
    }

    protected override void StartAdditional()
    {
        base.StartAdditional();
        isMonster = true;
    }

    protected override void Death()
    {
        CreateEffect();
        gameObject.SetActive(false);
        CreatePickUp();
    }

    public void CreatePickUp()
    {
        if (Chance())
        {
            {
                LeanPool.Spawn(pickUps[0], transform.position, Quaternion.identity);
            }
        }
    }

    bool Chance()
    {
        int chance = Random.Range(1, 100);
        if (chance < probability)
        {
            return true;
        }

        return false;
    }
    
    

    public void CreateEffect()
    {
        if (deathMonsterEffect != null)
        {
            var transform1 = transform;
            Vector3 effectPosition = transform1.position;
            Instantiate(deathMonsterEffect, effectPosition, transform1.rotation);
        }
    }
}