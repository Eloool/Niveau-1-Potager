using UnityEngine;

public class AugmentMaxSizeArrosoir : ShopBuff
{
    public override void Activate(int info)
    {
        InventairePerso.instance.setMaxArrosoir(info);
    }
}
