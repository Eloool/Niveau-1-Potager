using System.Collections;
using UnityEngine;

public class PlotJardin : Interaction
{
    private Legume legumeinplot;
    private bool IsPlotWatered;
    private Coroutine coroutineLegume;
    private LegumeInfo legumeBluprint;
    private GameObject GameObjectBlueprintPlant;
    private bool isBlueprint;

    private bool canPlant = true;
    private IEnumerator canplant()
    {
        canPlant = false;
        yield return new WaitForSeconds(1.5f);
        canPlant = true;

    }

    public bool isPlotWatered()
    {
        return IsPlotWatered;
    }

    public void setLegume(Legume legumeinplot)
    {
        this.legumeinplot = legumeinplot;
    }

    public Legume GetLegume() { return legumeinplot; }
    public LegumeInfo GetLegumeInfo() { return legumeBluprint; }

    public override void Interact(Inventaire inventaire)
    {
        if (inventaire is InventaireIA)
        {
            PlantGraine(inventaire);
        }
        else
        {
            if (isBlueprint)
            {
                if (inventaire.GetLegume())
                {
                    PlantBlueprint(inventaire.GetLegume());
                    if (legumeinplot == null)
                        OrganisationDrone.instance.AddPlotJardinPlantation(this);
                }
            }
            else
            {
                PlantGraine(inventaire);
            }
        }
    }
    private void PlantGraine(Inventaire inventaire)
    {
        if(inventaire is InventairePerso)
        {
            OrganisationDrone.instance.StopIAPlantationGoingToPlot(this,DroneStatus.Plantation,true);
        }
        if (legumeinplot == null && inventaire.canPlant() & canPlant)
        {
            legumeinplot = new Legume();
            legumeinplot.LoadInfo(inventaire.PlantLegume());
            legumeinplot.setPlotJardin(this);
            UpdateLegume();
            if (IsPlotWatered)
            {
                coroutineLegume = StartCoroutine(legumeinplot.UpdateLegume(inventaire));
            }
            else
            {
                OrganisationDrone.instance.AddPlotJardinWater(this);
            }
        }
        else if (legumeinplot != null && legumeinplot.stadeLegume == StadeLegume.mur)
        {
            StopCoroutine(coroutineLegume);
            coroutineLegume = null;
            legumeinplot.LegumeGotten(inventaire);
            StartCoroutine(canplant());
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
            if (isBlueprint)
            {
                legume.SetActive(false);
            }
        }
    }

    public void DestroyObject()
    {
        Destroy(legumeinplot.legumeObject);
        legumeinplot.legumeObject = null;
    }

    public void RemoveLegumeFromPlot(Inventaire inventaire)
    {
        if (coroutineLegume != null)
        {
            StopCoroutine(coroutineLegume);
        }
        bool isPerso =true;
        if(inventaire is InventaireIA)
        {
            isPerso = false;
        }
        OrganisationDrone.instance.StopIAPlantationGoingToPlot(this,DroneStatus.Recolte,isPerso);
        DestroyObject();
        legumeinplot = null;
        RemoveWater();
        if (legumeBluprint)
        {
            OrganisationDrone.instance.AddPlotJardinPlantation(this);
        }
    }

    public override void Water(Inventaire inventaire)
    {
        if (!IsPlotWatered)
        {
            IsPlotWatered = true;
            inventaire.Water();
            bool isPerso = true;
            if (inventaire is InventaireIA)
            {
                isPerso = false;
            }
            OrganisationDrone.instance.StopIAPlantationGoingToPlot(this,DroneStatus.Water,isPerso);
            if (legumeinplot != null)
            {
                UpdateLegume();
                coroutineLegume = StartCoroutine(legumeinplot.UpdateLegume(inventaire));
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

    public void ChangeVuePlant(bool isInBlueprint)
    {
        this.isBlueprint = isInBlueprint;

        if (GameObjectBlueprintPlant)
        {
            GameObjectBlueprintPlant.SetActive(isBlueprint);
        }
        legumeinplot?.legumeObject.SetActive(!isBlueprint);
    }
    public bool PlantBlueprint(LegumeInfo legumeInfo)
    {

        if (legumeBluprint && GameObjectBlueprintPlant)
        {
            OrganisationDrone.instance.StopIAPlantationGoingToPlot(this,DroneStatus.Plantation,true);
            legumeBluprint = null;
            Destroy(GameObjectBlueprintPlant);
        }
        legumeBluprint = legumeInfo;
        GameObjectBlueprintPlant = Instantiate(legumeInfo.stadeLegumeTimes[legumeInfo.stadeLegumeTimes.Count - 1].stadeLegume, transform);
        GameObjectBlueprintPlant.transform.localPosition = new Vector3(0, 2, 0);
        GameObjectBlueprintPlant.GetComponent<MeshRenderer>().material = BlueprintPlantation.Instance.materialBlueprint;
        return true;
    }
}
