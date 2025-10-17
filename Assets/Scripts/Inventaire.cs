using UnityEngine;

public class Inventaire : MonoBehaviour
{
    public static Inventaire instance;
    private LegumeInfo legumeInInventory;
    private float jaugeWater =0f;

    private void Start()
    {
        instance = this;
    }

    public void setLegume(LegumeInfo legume)
    {
        legumeInInventory = legume;
    }

    public LegumeInfo GetLegume()
    {
        return legumeInInventory;
    }

    public void RefillWater()
    {
        jaugeWater = 100f;
    }

    public bool Water()
    {
        if (jaugeWater > 0)
        {
            jaugeWater -= 0.01f;
            return true;
        }
        else
        {
            return false;
        }
    }
}
