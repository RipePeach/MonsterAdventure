using UnityEngine;

public class PickUp : MonoBehaviour

{
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out CharacterScript character))
        {
            Apply(character);
        }
    }

    public virtual void Apply(CharacterScript player)
    {
    }
}