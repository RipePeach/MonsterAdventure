using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartsManager : MonoBehaviour
{
    #region Singletone

    public static HeartsManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    #endregion

    [SerializeField] private List<Image> hearts = new List<Image>();
    [SerializeField] private Sprite _heartSprite;
    [SerializeField] private Sprite _transparentSprite;

    private BaseClass _player;
    private Health _health;

    void Start()
    {
        _player = FindObjectOfType<CharacterScript>();
        ChangeHearts();
        _player.onHealthChanged += ChangeHearts;
    }

    //замена спрайтов-сердец при изменении здороаья
    public void ChangeHearts()
    {
        for (int i = 0; i < _player.health; i++)
        {
            hearts[i].sprite = _heartSprite;
        }

        for (int i = _player.health; i < hearts.Count; i++)
        {
            hearts[i].sprite = _transparentSprite;
        }
    }
}