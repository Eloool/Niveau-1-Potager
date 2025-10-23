using UnityEngine;

public class ActivationDrone : ShopBuff
{
    public override void Activate(int info)
    {
        switch (info)
        {
            case 1:
                BlueprintPlantation.Instance.enabled = true;
                OrganisationDrone.instance.StartDrone(DroneStatus.Plantation);
                break;
            case 2:
                OrganisationDrone.instance.StartDrone(DroneStatus.Water);
                break;
            case 3:
                OrganisationDrone.instance.StartDrone(DroneStatus.Recolte);
                break;
            default:
                break;
        }
    }
}
