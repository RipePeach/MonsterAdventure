using UnityEngine;
using UnityEngine.UI;

public class BossUi : MonoBehaviour
{
    [SerializeField] private EnemyScript boss;

    [SerializeField] private Slider bossHealth;

    private EnemyScript _enemyScript;

    void Start()
    {
        bossHealth.maxValue = boss.health;
        bossHealth.value = boss.health;
        boss.onHealthChanged += UpdateSlider;
    }

    //Обновить полосу жизни, если изменено здоровье
    void UpdateSlider()
    {
        bossHealth.value = boss.health;
    }
}
