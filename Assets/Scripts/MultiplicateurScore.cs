using UnityEngine;

public class MultiplicateurScore : ShopBuff
{
    public override void Activate()
    {
        Score.instance.SetMultiplicateur(Score.instance.getMultiplicateur() * 2);
    }
}
