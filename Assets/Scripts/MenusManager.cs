using System.Collections.Generic;
using UnityEngine;

public class MenusManager : MonoBehaviour
{
    private GameObject menusInFront;

    public static MenusManager instance;

    private void Start()
    {
        instance = this;
    }


    public bool OpenCanvas(GameObject canvas)
    {
        if (!menusInFront)
        {
            menusInFront = canvas;
            DroneMovement.instance.enabled = false;
            DroneInteraction.instance.enabled = false;
            return true;
        }
        return false;

    }

    public void RemoveCanvas(GameObject canvas)
    {
        if(menusInFront == canvas)
        {
            menusInFront = null;
            DroneMovement.instance.enabled = true;
            DroneInteraction.instance.enabled = true;
        }
    }
    public void CloseCanvasByForce()
    {
        if (menusInFront)
        {
            menusInFront = null;
            DroneMovement.instance.enabled = true;
            DroneInteraction.instance.enabled = true;
        }
    }

}