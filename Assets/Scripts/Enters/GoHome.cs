using System.Collections;
using UnityEngine;

namespace Enters
{
    public class GoHome : MonoBehaviour
    {
        [SerializeField] private Vector2 newPlayerPosition = new Vector2(-1f, -1f);
        [SerializeField] private float dilayLoadScene;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.TryGetComponent(out CharacterScript character))
            {
                character.startPosition = newPlayerPosition;
                character.Save();
                StartCoroutine(LevelCoroutine());
            }
        }

        private IEnumerator LevelCoroutine()
        {
            yield return new WaitForSeconds(dilayLoadScene);
            SceneLoader.Instance.LoadLevel(3);
        }
    }
}