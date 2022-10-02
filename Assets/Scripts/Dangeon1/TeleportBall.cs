using UnityEngine;

public class TeleportBall : Bullets
{
    //телепорт вернет плеера в начало уровня
    [SerializeField] Transform destinationPoint;
    //летит справа или слева
    [SerializeField] private bool right = true;

    public override void ApplyEffect(BaseClass obj)
    {
        base.ApplyEffect(obj);
        Teleport(obj);
    }

    public override Vector2 Direction()
    {
        if (right)
        {
            return Vector2.right;
        }

        return Vector2.left;
    }

    void Teleport(BaseClass obj)
    {
        obj.transform.position = destinationPoint.position;
    }
}