using UnityEngine;

public class Arrosoir : Interaction
{
    public override void Interact()
    {
        Inventaire.instance.RefillWater();
    }
}
