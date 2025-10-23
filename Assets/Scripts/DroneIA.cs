using System.Collections.Generic;
using UnityEngine;

public class DroneIA : MonoBehaviour
{
    private PlotJardin plotJardinNext;
    public Transform restingPlace;
    private InventaireIA inventaire;
    private InteractionIA interaction;
    private MovementIA movement;
    private bool isActing = false;
    private Coroutine coroutine;
    public List<Vector3> route = new List<Vector3>();

    private void Start()
    {
        OrganisationDrone.instance.AddDrone(this);
        inventaire = GetComponent<InventaireIA>();
        interaction = GetComponent<InteractionIA>();
        movement = GetComponent<MovementIA>();
    }

    public virtual bool NextTarget(PlotJardin plotJardin)
    {
        StopCoroutineDrone();
        if ((!plotJardinNext && !plotJardin) && !isActing && Vector3.Distance(transform.position, restingPlace.position) < 0.3f)
        {
            return false;
        }
        plotJardinNext = plotJardin;
        return true;

    }

    public virtual void AfterMoving(int cpt)
    {

    }

    public virtual void FinishTask()
    {
        route.Clear();
        isActing = false;
        plotJardinNext =null;
    }

    public void StopCoroutineDrone()
    {
        if (coroutine != null)
        { 
            StopCoroutine(coroutine);
            coroutine = null;
        }
    }

    public void SetActing(bool Acting)
    {
        isActing = Acting;
    }

    public bool IsActing()
    {
        return isActing;
    }
    public InventaireIA getInventaire()
    {
        return inventaire;
    }

    public InteractionIA GetInteraction()
    {
        return interaction;
    }
    public MovementIA GetMovement()
    {
        return movement;
    }
    public void SetCoroutine(Coroutine coroutine)
    {
        this.coroutine = coroutine;
    }
    public PlotJardin GetPlotJardinNext()
    {
        return plotJardinNext;
    }

    public bool isInResting()
    {
        return Vector3.Distance(transform.position, restingPlace.position) < 0.2f && !isActing;
    }
}
