using UnityEngine;

public class PlotJardin : Interaction
{
    private Legume legumeinplot;
    private bool IsPlotWatered;
    private Coroutine coroutineLegume;

    public bool isPlotWatered()
    {
        return IsPlotWatered;
    }

    public void setLegume(Legume legumeinplot)
    {
        this.legumeinplot = legumeinplot;
    }

    public Legume GetLegume() { return legumeinplot; }

    public override void Interact()
    {
        if (legumeinplot == null && Inventaire.instance.GetLegume())
        {
            legumeinplot = new Legume();
            legumeinplot.LoadInfo(Inventaire.instance.GetLegume());
            legumeinplot.setPlotJardin(this);
            UpdateLegume();
            if (IsPlotWatered)
            {
                coroutineLegume = StartCoroutine(legumeinplot.UpdateLegume());
            }
        }
        else if (legumeinplot != null && legumeinplot.stadeLegume == StadeLegume.mur)
        {
            StopCoroutine(coroutineLegume);
            coroutineLegume = null;
            legumeinplot.LegumeGotten();
        }
    }

    public void UpdateLegume()
    {
        if (legumeinplot.legumeObject != null)
        {
            DestroyObject();
        }
        if (legumeinplot.legumeObject == null)
        {
            GameObject legume = Instantiate(legumeinplot.getCurrentStadeLegumeObject(), transform);
            legume.transform.localPosition = new Vector3(0, 2, 0);
            legumeinplot.legumeObject = legume;
        }
    }

    public void DestroyObject()
    {
        Destroy(legumeinplot.legumeObject);
        legumeinplot.legumeObject = null;
    }

    public void RemoveLegumeFromPlot()
    {
        if (coroutineLegume !=null)
        {
            StopCoroutine(coroutineLegume);
        }
        DestroyObject();
        legumeinplot = null;
        RemoveWater();
    }

    public override void Water()
    {
        if (!IsPlotWatered)
        {
            IsPlotWatered = true;
            if (legumeinplot != null)
            {
                UpdateLegume();
                coroutineLegume = StartCoroutine(legumeinplot.UpdateLegume());
            }
            Material material = GetComponent<Renderer>().material;
            material.SetFloat("_Metallic", 0.5f);
        }
    }

    private void RemoveWater()
    {
        IsPlotWatered = false;
        Material material = GetComponent<Renderer>().material;
        material.SetFloat("_Metallic", 0f);
    }
}
