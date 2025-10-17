using UnityEngine;

public class PanneauLegume : Interaction
{
    public LegumeInfo legumeGiven;

    public override void Interact()
    {
        Inventaire.instance.setLegume(legumeGiven);
    }

    private void OnDisable()
    {
        legumeGiven = null;
    }

}
