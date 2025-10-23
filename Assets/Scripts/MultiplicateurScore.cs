using UnityEngine;

public class MultiplicateurScore : ShopBuff
{
    public override void Activate(int info)
    {
        Score.instance.SetMultiplicateur(info);
        PorteMonnaie.instance.SetMultiplicateur(info);
    }
}
