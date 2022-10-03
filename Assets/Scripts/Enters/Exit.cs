
using UnityEngine;

public class Exit : MonoBehaviour
{
    [SerializeField] Vector2 newPlayerPosition = new Vector2(x: -29.5f, y: -20f);
    private CharacterScript _character;

    private void Start()
    {
        _character = FindObjectOfType<CharacterScript>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Character"))
        {
            // Character's data
            _character.startPosition = newPlayerPosition;
            _character.Save();
            //FirebaseAnalytics.LogEvent("LoadSceneMainScene", new Parameter("LoadScene", 1));
            SceneLoader.Instance.LoadNextSceneByName("MainScene");
        }
    }
}