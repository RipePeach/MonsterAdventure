using UnityEngine;
using Lean.Pool;

public class Portal : MonoBehaviour
{
    #region Singletone

    public static Portal Instance { get; private set; }

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
    [SerializeField] private ParticleSystem portalEffect;
    
    private bool _onEnablePortal;
    private Collider2D _collider2D;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<CharacterScript>())
        {
            collision.GetComponent<CharacterScript>().Save();
            collision.GetComponent<CharacterScript>().startPosition = new Vector2(-1, -1);
            SceneLoader.Instance.LoadLevel(3);
        }
    }
    void Start()
    {
        _collider2D = GetComponent<Collider2D>();
        _onEnablePortal = false;
        enabled = false;
        _collider2D.enabled = false;
    }

    public void OnEnablePortal()
    {
        _onEnablePortal = true;
        enabled = true;
        _collider2D.enabled = true;
    }
    
    public void NextLevelEffect()
    {
        if (portalEffect != null)
        {
            Vector2 fxPosition = transform.position;
            LeanPool.Spawn(portalEffect, fxPosition, Quaternion.identity);
        }
    }
}
