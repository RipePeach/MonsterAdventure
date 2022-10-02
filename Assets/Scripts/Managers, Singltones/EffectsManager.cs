using Lean.Pool;
using UnityEngine;

namespace Managers__Singltones
{
    public class EffectsManager : MonoBehaviour
    {
        [Header("Effects")] [SerializeField] private GameObject attackCharacterEffect;

        private CharacterScript _character;

        private void Awake()
        {
            _character = FindObjectOfType<CharacterScript>();
            _character.OnAttack += OnAttack;
        }

        private void OnAttack()
        {
            if (attackCharacterEffect != null)
            {
                var attackPos = _character.transform.position;
                Instantiate(attackCharacterEffect, attackPos, Quaternion.identity);
            }
        }
    }
}