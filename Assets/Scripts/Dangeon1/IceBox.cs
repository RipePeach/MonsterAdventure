using System;
using UnityEngine;

public class IceBox : BaseClass
{
    private CharacterScript _character;

    protected override void StartAdditional()
    {
        base.StartAdditional();
        _character = FindObjectOfType<CharacterScript>();
    }

    // После уничтожения IceBox плеер может двигаться. Дестрой леда-бокса
    protected override void Death()
    {
        _character.Frozen = false;
        Destroy(gameObject);
    }
}