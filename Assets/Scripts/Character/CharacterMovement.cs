using UnityEngine;

public class CharacterMovement : Movement
{
    private static readonly int LastMoveX = Animator.StringToHash("LastMoveX");
    private static readonly int LastMoveY = Animator.StringToHash("LastMoveY");
    private const string HORIZONTAL = "Horizontal";
    private const string VERTICAL = "Vertical";

    protected override void Update()
    {
        ApplyAnimation();
    }

    protected override void FixedUpdate()
    {
        Move();
    }

    public override void ApplyAnimation()
    {
        base.ApplyAnimation();
        if (Input.GetAxisRaw(HORIZONTAL) == 1 || Input.GetAxisRaw(HORIZONTAL) == -1 ||
            Input.GetAxisRaw(VERTICAL) == 1 || Input.GetAxisRaw(VERTICAL) == -1)
        {
            Animator.SetFloat(LastMoveX, Input.GetAxisRaw(HORIZONTAL));
            Animator.SetFloat(LastMoveY, Input.GetAxisRaw(VERTICAL));
        }
    }

    protected override Vector3 Direction()
    {
        //вернет значение -1 , если движение влево
        float inputX = Input.GetAxisRaw(HORIZONTAL) * Time.deltaTime;
        //вернет значение -1, если движение вниз
        float inputY = Input.GetAxisRaw(VERTICAL) * Time.deltaTime;
        return new Vector3(inputX, inputY);
    }
}