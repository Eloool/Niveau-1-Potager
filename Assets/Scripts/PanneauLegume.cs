using UnityEngine;

public class PanneauLegume : Interaction
{
    public LegumeInfo legumeGiven;

    public override void Interact(Inventaire inventaire)
    {
       inventaire.refillLegume(legumeGiven);
    }

    private void OnDisable()
    {
        legumeGiven = null;
    }

}
