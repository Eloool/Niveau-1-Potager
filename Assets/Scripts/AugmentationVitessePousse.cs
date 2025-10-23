using UnityEngine;

public class AugmentationVitessePousse : ShopBuff
{
    public override void Activate(int info)
    {
        float mult = (float)info / 100;
        Jardin.instance.setMultiplicateur(mult);
    }
}
