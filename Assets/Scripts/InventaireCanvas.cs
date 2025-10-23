using TMPro;
using UnityEngine;

public class InventaireCanvas : MonoBehaviour
{
    public TextMeshProUGUI textInventaire;

    public static InventaireCanvas instance;

    private void Awake()
    {
        instance = this;
    }


    public void UpdateCanvasInventaire()
    {
        if (InventairePerso.instance.GetLegume())
        {
            textInventaire.text = "Inventaire :" + InventairePerso.instance.getNumberOfSeeds() + " graines de " + InventairePerso.instance.GetLegume().nom;
        }
        else
        {
            textInventaire.text = "Pas de graines dans l'inventaire.";
        }
        
    }
}
