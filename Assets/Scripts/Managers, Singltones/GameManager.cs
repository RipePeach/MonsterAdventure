using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool loadGame;

    void Start()
    {
        loadGame = true;
        //не удалять при загрузке
        DontDestroyOnLoad(gameObject);
    }
}