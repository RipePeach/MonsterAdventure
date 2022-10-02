using System.Collections;
using UnityEngine;

public class GoToDangeon : MonoBehaviour
{
    [SerializeField] private float dilaySceneLoad = 2f;
    private Vector2 newPlayerPosition = new Vector3(x: 1.52f, y: -41.85f);

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out CharacterScript character))
        {
            character.startPosition = newPlayerPosition;
            character.Save();
            StartCoroutine(LevelCoroutine());
        }
    }

    private IEnumerator LevelCoroutine()
    {
        yield return new WaitForSeconds(dilaySceneLoad);
        //samleScene
        SceneLoader.Instance.LoadLevel(1);
    }
}