using UnityEngine;

public class PlotJardin : MonoBehaviour
{
    private Legume legumeinplot;

    public void setLegume(Legume legumeinplot)
    {
        this.legumeinplot = legumeinplot;
    }

    public Legume GetLegume() { return legumeinplot; }

    public void AddLegumeToPlot(Legume legume)
    {

    }
}
