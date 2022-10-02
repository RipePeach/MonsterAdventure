using Components;
using UnityEngine;

public class Water : MonoBehaviour
{
    public Collider2D _collider2D;

    //возмможность пройти 
    public void OnCollisionEnter2D(Collision2D other1)
    {
        if (other1.gameObject.GetComponent<FreezingComponent>())
        {
            _collider2D.enabled = false;
        }
    }
  }
