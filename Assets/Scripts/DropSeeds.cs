using UnityEngine;

public class DropSeeds : Interaction
{
    public override void Interact(Inventaire inventaire)
    {
        inventaire.EmptyInventory();
    }
}
