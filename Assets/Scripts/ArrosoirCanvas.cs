using UnityEngine;
using UnityEngine.UI;

public class ArrosoirCanvas : MonoBehaviour
{
    public static ArrosoirCanvas instance;
    private Slider slider;

    private void Awake()
    {
        instance = this;
        slider = GetComponent<Slider>();
    }
    public void UpdateCanvas()
    {
        slider.value = InventairePerso.instance.getJaugeWater();
    }
    public void SetMaxValue(float value)
    {
        slider.maxValue = value;
    }
}
