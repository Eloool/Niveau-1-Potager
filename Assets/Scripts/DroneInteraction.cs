using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class DroneInteraction : InteractionBase
{
    public InputActionReference interact;
    public InputActionReference water;

    private Coroutine coroutine;
    public static DroneInteraction instance;

    private void Start()
    {
        instance = this;
    }
    public void LaunchRayInteractDrone(InputAction.CallbackContext callbackContext)
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down * 10), out hit, Mathf.Infinity, maskTarget))
        {
            hit.transform.gameObject.GetComponent<Interaction>().Interact(InventairePerso.instance);
        }
    }

    private void OnEnable()
    {
        interact.action.performed += LaunchRayInteractDrone;
    }
    
    private void Update()
    {
        if (water.action.WasReleasedThisFrame())
        {
            if (coroutine != null)
            {
                StopCoroutine(coroutine);
                coroutine = null;
            }
        }
        if (water.action.WasPressedThisFrame())
        {
            coroutine = StartCoroutine(WAterPlot());
        }
    }

    private void OnDisable()
    {
        if (coroutine !=null)
        {
            StopCoroutine (coroutine);
            coroutine =null;
        }
        interact.action.performed -= LaunchRayInteractDrone;
    }
    public IEnumerator WAterPlot()
    {
        while (true)
        {
            yield return new WaitForEndOfFrame();
            LaunchRayWater(InventairePerso.instance);
        }
    }
}
