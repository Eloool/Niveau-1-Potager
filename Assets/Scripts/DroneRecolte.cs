using UnityEngine;

public class DroneRecolte : DroneIA
{
    public override void AfterMoving(int cpt)
    {
        GetInteraction().LaunchRayInteract(getInventaire());
    }

    public override void FinishTask()
    {
        base.FinishTask();
        OrganisationDrone.instance.UpdateDrone(DroneStatus.Recolte, this);
    }

    public override bool NextTarget(PlotJardin plotJardin)
    {
        bool isResting = base.NextTarget(plotJardin);
        if (plotJardin != null)
        {
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
