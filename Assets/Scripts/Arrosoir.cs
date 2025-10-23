using UnityEngine;

public class Arrosoir : Interaction
{
    public override void Interact(Inventaire invetaire)
    {
        invetaire.RefillWater();
    }
}
