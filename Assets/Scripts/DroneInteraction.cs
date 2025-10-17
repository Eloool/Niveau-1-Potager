using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class DroneInteraction : MonoBehaviour
{
    public InputActionReference interact;
    public InputActionReference water;
    public LayerMask maskJardin;

    private Coroutine coroutine;

    private void Start()
    {
        interact.action.performed += LaunchRayInteract;
    }
    public void LaunchRayInteract(InputAction.CallbackContext callbackContext)
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down * 10), out hit, Mathf.Infinity, maskJardin))
        {
            hit.transform.gameObject.GetComponent<Interaction>().Interact();
        }
    }

    public void LaunchRayWater()
    {
        if (Inventaire.instance.Water())
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down * 10), out hit, Mathf.Infinity, maskJardin))
            {
                hit.transform.gameObject.GetComponent<Interaction>().Water();
            }
        }
    }

    private void Update()
    {
        if (water.action.WasReleasedThisFrame())
        {
            StopCoroutine(coroutine);
        }
        if (water.action.WasPressedThisFrame())
        {
            coroutine = StartCoroutine(WAterPlot());
        }
    }

    public IEnumerator WAterPlot()
    {
        while (true)
        {
            yield return new WaitForEndOfFrame();
            LaunchRayWater() ;
        }
    }
    private void OnDisable()
    {
        interact.action.performed -= LaunchRayInteract;
    }
}
