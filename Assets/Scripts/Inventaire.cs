using UnityEngine;

public class Inventaire : MonoBehaviour
{
    public static Inventaire instance;
    private int numberOfSeeds = 0;
    private int numberMaxOfSeeds = 5;
    private LegumeInfo legumeInInventory;
    private float jaugeWater =0f;
    private float jaugeWaterMax = 100f;

    private void Start()
    {
        instance = this;
        ArrosoirCanvas.instance.SetMaxValue(jaugeWaterMax);
    }

    public LegumeInfo PlantLegume()
    {
        if (numberOfSeeds > 0)
        {
            numberOfSeeds--;
            return legumeInInventory;
        }
        else
        {
            legumeInInventory = null;
            return null;
        }
    }
    public void RefillWater()
    {
        jaugeWater = jaugeWaterMax;
        ArrosoirCanvas.instance.UpdateCanvas();
    }

    public bool Water()
    {
        if (jaugeWater > 0)
        {
            jaugeWater -= 0.5f;
            ArrosoirCanvas.instance.UpdateCanvas();
            return true;
        }
        else
        {
            return false;
        }
    }
    
    public float getJaugeWater()
    {
        return jaugeWater;
    }
    
    public void refillLegume(LegumeInfo legume)
    {
        legumeInInventory = legume;
        numberOfSeeds = numberMaxOfSeeds;
    }

    public bool canPlant()
    {
        return numberOfSeeds > 0 && legumeInInventory;
    }

    public void setNumberMaxofSeeds(int numberMaxofSeeds)
    {
        this.numberMaxOfSeeds = numberMaxofSeeds;
    }
    public void setMaxArrosoir(float maxArrosoir)
    {
        this.jaugeWaterMax = maxArrosoir;
        ArrosoirCanvas.instance.SetMaxValue(jaugeWaterMax);
    }
}
