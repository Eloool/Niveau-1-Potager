using UnityEngine;

public class DronePlantation : DroneIA
{
    public override void AfterMoving(int cpt)
    {
        GetInteraction().LaunchRayInteract(getInventaire());
    }

    public override void FinishTask()
    {
        base.FinishTask();
        OrganisationDrone.instance.UpdateDrone(DroneStatus.Plantation, this);

    }
    public override bool NextTarget(PlotJardin plotJardin)
    {
        bool isResting = base.NextTarget(plotJardin);
        if (plotJardin != null)
        {
            if (getInventaire().GetLegume() == null || getInventaire().GetLegume().nom != plotJardin.GetLegumeInfo().nom || getInventaire().getNumberOfSeeds() <= 0)
            {
                Vector3 posPanneau = Jardin.instance.GetPanneau(plotJardin.GetLegumeInfo()).transform.position;
                posPanneau.y = transform.position.y;
                route.Add(posPanneau);
            }

            route.Add(new Vector3(plotJardin.transform.position.x, transform.position.y, plotJardin.transform.position.z));
        }
        if (isResting)
        {
            route.Add(restingPlace.position);
            SetCoroutine(StartCoroutine(GetMovement().Move()));
        }
        return true;
    }
}
