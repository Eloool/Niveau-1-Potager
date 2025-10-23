using UnityEngine;

public class AugmentionMaxInventaire : ShopBuff
{
    public override void Activate(int info)
    {
        InventairePerso.instance.setNumberMaxofSeeds(info);
    }
}
