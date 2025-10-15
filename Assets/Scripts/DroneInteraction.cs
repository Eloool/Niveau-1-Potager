using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class DroneInteraction : MonoBehaviour
{
    public InputActionReference interact;
    public LayerMask maskJardin;

    private void Start()
    {
        interact.action.performed += LaunchRayInteract;
    }
    public void LaunchRayInteract(InputAction.CallbackContext callbackContext)
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, maskJardin))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            Debug.Log("Did Hit");
        }
    }

    private void OnDisable()
    {
        interact.action.performed -= LaunchRayInteract;
    }
}
