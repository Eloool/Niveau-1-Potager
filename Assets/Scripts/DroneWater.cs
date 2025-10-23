using UnityEngine;

public class DroneWater : DroneIA
{
    private Vector3 plotJardinFOrTesting;

    public override void AfterMoving(int cpt)
    {
        Vector3 posPanneau = Jardin.instance.getArrosoir().transform.position;
        posPanneau.y = transform.position.y;
        if (cpt < route.Count)
        {
            if (route[cpt - 1] == posPanneau)
            {
                GetInteraction().LaunchRayInteract(getInventaire());
            }
            else if (route[cpt - 1] == plotJardinFOrTesting)
            {
                GetInteraction().LaunchRayWater(getInventaire());
            }
        }
    }

    public override void FinishTask()
    {
        base.FinishTask();
        OrganisationDrone.instance.UpdateDrone(DroneStatus.Water, this);
    }


    public override bool NextTarget(PlotJardin plotJardin)
    {
        //Debug.Log(plotJardin, plotJardin);
        bool isResting = base.NextTarget(plotJardin);
        if (plotJardin != null)
        {
            if (getInventaire().getJaugeWater() <=5f)
            {
                Vector3 posPanneau = Jardin.instance.getArrosoir().transform.position;
                posPanneau.y = transform.position.y;
                route.Add(posPanneau);
            }
            plotJardinFOrTesting = new Vector3(plotJardin.transform.position.x, transform.position.y, plotJardin.transform.position.z);
            route.Add(plotJardinFOrTesting);
        }
        if (isResting)
        {
            route.Add(restingPlace.position);
            SetCoroutine(StartCoroutine(GetMovement().Move()));
        }
        return true;
    }
}
