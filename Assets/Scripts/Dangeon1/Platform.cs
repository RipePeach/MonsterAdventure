using UnityEngine;
using DG.Tweening;

public class Platform : BaseClass
{
    [Header("Positions")] 
    [SerializeField] bool forward;

    [SerializeField] bool back;

    [SerializeField] bool left;

    [SerializeField] bool right;

    [Header("Distance")] [SerializeField] float units;

    [Header("CheckPLayer")] [SerializeField]
    private LayerMask platform;

    [SerializeField] private float platformInRadius = 1f;

    private float _targetRight;
    private float _targetLeft;
    private float _targetForward;
    private float _targetBack;

    private void Start()
    {
        // сохранить состояние
        var position = transform.position;
        _targetRight = position.x + units;
        _targetLeft = position.x - units;
        _targetForward = position.y + units;
        _targetBack = position.y - units;
    }

    public void Move()
    {
        if (forward)
        {
            transform.DOMoveY(_targetForward, duration: 1);
        }

        if (back)
        {
            transform.DOMoveY(_targetBack, 1);
        }

        if (left)
        {
            transform.DOMoveX(_targetLeft, 1);
        }

        if (right)
        {
            transform.DOMoveX(_targetRight, 1);
        }
    }
}