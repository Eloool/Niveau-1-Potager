using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class InteractionBase : MonoBehaviour
{
    public LayerMask maskTarget;
    public void LaunchRayInteract(Inventaire inventaire)
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down * 10), out hit, Mathf.Infinity, maskTarget))
        {
            hit.transform.gameObject.GetComponent<Interaction>().Interact(inventaire);
        }
    }

    public void LaunchRayWater(Inventaire inventaire)
    {
        if (inventaire.Water())
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down * 10), out hit, Mathf.Infinity, maskTarget))
            {
                hit.transform.gameObject.GetComponent<Interaction>().Water(inventaire);
            }
        }
    }

    
}
