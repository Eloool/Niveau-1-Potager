using UnityEngine;

public class InventairePerso : Inventaire
{
    public static InventairePerso instance;


    private void Start()
    {
        instance = this;
        ArrosoirCanvas.instance.SetMaxValue(getJaugeMaxWater());
        InventaireCanvas.instance.UpdateCanvasInventaire();
    }


    public override LegumeInfo PlantLegume()
    {
        if (getNumberOfSeeds() > 0)
        {
            SetNumberOfSeed(getNumberOfSeeds()-1);
            InventaireCanvas.instance.UpdateCanvasInventaire();
            return GetLegume();
        }
        else
        {
            SetLegume(null);
            InventaireCanvas.instance.UpdateCanvasInventaire();
            return null;
        }
    }
    public override void RefillWater()
    {
        SetJaugeWater(getJaugeMaxWater());
        ArrosoirCanvas.instance.UpdateCanvas();
    }

    public override bool Water()
    {
        if (getJaugeWater() > 0)
        {
            SetJaugeWater(getJaugeWater() -0.5f);
            ArrosoirCanvas.instance.UpdateCanvas();
            return true;
        }
        else
        {
            return false;
        }
    }
    
    public override void refillLegume(LegumeInfo legume)
    {
        SetLegume(legume);
        SetNumberOfSeed(GetNumberMaxOfSeeds());
        InventaireCanvas.instance.UpdateCanvasInventaire();
    }

    public override void setMaxArrosoir(float maxArrosoir)
    {
        base.setMaxArrosoir(maxArrosoir);
        ArrosoirCanvas.instance.SetMaxValue(getJaugeMaxWater());
    }
}
