public class IceBall : Bullets
{
    public override void ApplyEffect(BaseClass obj)
    {
        //урон
        base.ApplyEffect(obj);
        //создание
        obj.Freeze();
    }
}