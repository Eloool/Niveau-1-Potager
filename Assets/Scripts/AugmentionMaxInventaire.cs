using UnityEngine;

public class AugmentionMaxInventaire : ShopBuff
{
    public override void Activate(int info)
    {
        Inventaire.instance.setNumberMaxofSeeds(info);
    }
}
