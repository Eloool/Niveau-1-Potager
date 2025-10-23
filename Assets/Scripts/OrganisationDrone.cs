using System.Collections.Generic;
using UnityEngine;

public class OrganisationDrone : MonoBehaviour
{
    public static OrganisationDrone instance;
    private List<PlotJardin> plotJardinsPlantation = new List<PlotJardin>();
    private List<PlotJardin> plotJardinsWater = new List<PlotJardin>();
    private List<PlotJardin> plotJardinsRecolte = new List<PlotJardin>();

    private List<DroneIA> droneIAs = new List<DroneIA>();

    public List<GameObject> drones = new List<GameObject>();

    private void Awake()
    {
        instance = this;
    }

    public void AddPlotJardinPlantation(PlotJardin plotJardin)
    {
        if (!plotJardinsPlantation.Contains(plotJardin))
            plotJardinsPlantation.Add(plotJardin);
        UpdateDrone(DroneStatus.Plantation);
    }

    public void AddPlotJardinWater(PlotJardin plotJardin)
    {
        if (!plotJardinsWater.Contains(plotJardin))
            plotJardinsWater.Add(plotJardin);
        UpdateDrone(DroneStatus.Water);
    }
    public void AddPlotJardinRecolte(PlotJardin plotJardin)
    {
        if (!plotJardinsRecolte.Contains(plotJardin))
            plotJardinsRecolte.Add(plotJardin);
        UpdateDrone(DroneStatus.Recolte);
    }

    public PlotJardin getPlotJardinPlantation()
    {
        if (plotJardinsPlantation.Count > 0)
        {
            PlotJardin plotJardin = plotJardinsPlantation[0];
            plotJardinsPlantation.Remove(plotJardin);
            return plotJardin;
        }
        return null;
    }
    public PlotJardin getPlotJardinWater()
    {
        if (plotJardinsWater.Count > 0)
        {
            PlotJardin plotJardin = plotJardinsWater[0];
            plotJardinsWater.Remove(plotJardin);
            return plotJardin;
        }
        return null;
    }
    public PlotJardin getPlotJardinRecolte()
    {
        if (plotJardinsRecolte.Count > 0)
        {
            PlotJardin plotJardin = plotJardinsRecolte[0];
            plotJardinsRecolte.Remove(plotJardin);
            return plotJardin;
        }
        return null;
    }

    public void RemovePlotJardinPlantation(PlotJardin plotJardin, DroneIA drone)
    {
        plotJardinsPlantation.Remove(plotJardin);
    }

    public void RemovePlotJardinWater(PlotJardin plotJardinWater, DroneIA drone)
    {
        plotJardinsWater.Remove(plotJardinWater);
    }

    public void RemovePlotJardinRecolte(PlotJardin plotJardinRecolte, DroneIA drone)
    {
        plotJardinsRecolte.Remove(plotJardinRecolte);
    }

    public void UpdateDrone(DroneStatus droneStatus, DroneIA drone = null)
    {
        if (!drone)
        {
            drone = getFirstDrone(droneStatus);
        }
        if (drone)
        {
            PlotJardin plotJardin = null;
            switch (droneStatus)
            {
                case DroneStatus.Plantation:
                    plotJardin = getPlotJardinPlantation();
                    break;
                case DroneStatus.Water:
                    plotJardin = getPlotJardinWater();
                    break;
                case DroneStatus.Recolte:
                    plotJardin = getPlotJardinRecolte();
                    break;
                default:
                    break;
            }
            if (plotJardin)
            {
                drone.SetActing(true);
            }
            drone.NextTarget(plotJardin);
        }
    }
    public void AddDrone(DroneIA drone)
    {
        droneIAs.Add(drone);
    }

    public void StopIAPlantationGoingToPlot(PlotJardin plotJardin, DroneStatus droneStatus, bool needActingDrone)
    {
        DroneIA drone = null;
        if (needActingDrone)
        {
            drone = GetDrone(droneStatus);
        }
        else
        {
            drone = getFirstDrone(droneStatus);
        }
        if (drone && drone.GetPlotJardinNext() == plotJardin)
        {
            drone.route.Clear();
            UpdateDrone(droneStatus, drone);
        }
        switch (droneStatus)
        {
            case DroneStatus.Recolte:
                if (plotJardinsRecolte.Contains(plotJardin))
                {
                    plotJardinsRecolte.Remove(plotJardin);
                }
                break;
            case DroneStatus.Plantation:
                if (plotJardinsPlantation.Contains(plotJardin))
                {
                    plotJardinsPlantation.Remove(plotJardin);
                }
                break;
            case DroneStatus.Water:
                if (plotJardinsWater.Contains(plotJardin))
                {
                    plotJardinsWater.Remove(plotJardin);
                }
                break;
            default:
                break;
        }

    }

    private DroneIA GetDrone(DroneStatus status)
    {
        DroneIA drone = null;

        switch (status)
        {
            case DroneStatus.Plantation:
                drone = droneIAs.Find(IsPlantation);
                break;
            case DroneStatus.Water:
                drone = droneIAs.Find(IsWater);
                break;
            case DroneStatus.Recolte:
                drone = droneIAs.Find(IsRecolte);
                break;
            default:
                break;
        }
        return drone;
    }


    private DroneIA getFirstDrone(DroneStatus status)
    {
        DroneIA drone = null;

        switch (status)
        {
            case DroneStatus.Plantation:
                    drone = getFirstNotActing(droneIAs.FindAll(IsPlantation));
                    break;
            case DroneStatus.Water:
                    drone = getFirstNotActing(droneIAs.FindAll(IsWater));
                    break;
            case DroneStatus.Recolte:
                    drone = getFirstNotActing(droneIAs.FindAll(IsRecolte));
                    break;
            default:
                break;
        }
        return drone;
    }

    private DroneIA getFirstNotActing(List<DroneIA> drones)
    {
        DroneIA drone = null;
        int cpt = 0;
        while (!drone && cpt < drones.Count)
        {
            if (!drones[cpt].IsActing())
            {
                drone = drones[cpt];
            }
            cpt++;
        }
        return drone;
    }
    private static bool IsPlantation(DroneIA drone)
    {
        return drone is DronePlantation;
    }
    private static bool IsWater(DroneIA drone)
    {
        return drone is DroneWater;
    }
    private static bool IsRecolte(DroneIA drone)
    {
        return drone is DroneRecolte;
    }

    public void StartDrone(DroneStatus droneStatus)
    {
        List<DroneIA> drones = new List<DroneIA>();
        foreach(GameObject drone in this.drones)
        {
            drones.Add(drone.GetComponent<DroneIA>());
        }
        DroneIA drone1 = null;
        switch (droneStatus)
        {
            case DroneStatus.Plantation:
                drone1 = drones.Find(IsPlantation);
                break;
            case DroneStatus.Water:
                drone1 = drones.Find(IsWater);
                break;
            case DroneStatus.Recolte:
                drone1 = drones.Find(IsRecolte);
                break;
            default:
                break;
        }
        drone1.gameObject.SetActive(true);
        UpdateDrone(droneStatus, drone1);
    }
}

public enum DroneStatus
{
    Plantation,
    Water,
    Recolte
}