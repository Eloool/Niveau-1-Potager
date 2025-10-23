using UnityEngine;

public class Inventaire : MonoBehaviour
{
    private int numberOfSeeds = 0;
    private int numberMaxOfSeeds = 5;
    private LegumeInfo legumeInInventory;
    private float jaugeWater = 0f;
    private float jaugeWaterMax = 100f;

    public virtual LegumeInfo PlantLegume()
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
    public virtual void RefillWater()
    {
        jaugeWater = jaugeWaterMax;
    }

    public virtual bool Water()
    {
        if (jaugeWater > 0)
        {
            jaugeWater -= 0.5f;
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
    public float getJaugeMaxWater()
    {
        return jaugeWaterMax;
    }

    public virtual void refillLegume(LegumeInfo legume)
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
    public virtual void setMaxArrosoir(float maxArrosoir)
    {
        this.jaugeWaterMax = maxArrosoir;
    }

    public LegumeInfo GetLegume()
    {
        return legumeInInventory;
    }

    public int getNumberOfSeeds()
    {
        return numberOfSeeds;
    }
    public void SetLegume(LegumeInfo legume)
    {
        legumeInInventory = legume;
    }
    public void SetJaugeWater(float water)
    {
        jaugeWater = water;
    }

    public void SetNumberOfSeed(int numberOfSeeds)
    {
        this.numberOfSeeds = numberOfSeeds;
    }

    public int GetNumberMaxOfSeeds()
    {
        return numberMaxOfSeeds;
    }
}
