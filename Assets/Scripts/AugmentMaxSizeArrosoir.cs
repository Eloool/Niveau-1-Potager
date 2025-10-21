using UnityEngine;

public class AugmentMaxSizeArrosoir : ShopBuff
{
    public override void Activate()
    {
        Inventaire.instance.setMaxArrosoir(200);
    }
}
