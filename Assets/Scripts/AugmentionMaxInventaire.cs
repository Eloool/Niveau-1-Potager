using UnityEngine;

public class AugmentionMaxInventaire : ShopBuff
{
    public override void Activate()
    {
        Inventaire.instance.setNumberMaxofSeeds(10);
    }
}
