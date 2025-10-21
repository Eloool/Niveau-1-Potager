using UnityEngine;

public class AugmentMaxSizeArrosoir : ShopBuff
{
    public override void Activate(int info)
    {
        Inventaire.instance.setMaxArrosoir(info);
    }
}
