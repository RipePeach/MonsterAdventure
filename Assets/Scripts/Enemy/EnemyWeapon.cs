using System.Collections;
using Lean.Pool;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    [SerializeField] private float delay = 2f;
    [SerializeField] private float rate = 1f;
    [SerializeField] private Bullets fireBallPrefab;

    private bool _canShoot = true;

    void Start()
    {
        StartCoroutine(CreateFireBalls(delay, rate));
    }

    IEnumerator CreateFireBalls(float delay, float rate)
    {
        yield return new WaitForSeconds(delay);
        while (_canShoot)
        {
            var transform1 = transform;
            LeanPool.Spawn(fireBallPrefab, transform1.position, transform1.rotation);
            yield return new WaitForSeconds(rate);
        }
    }
}