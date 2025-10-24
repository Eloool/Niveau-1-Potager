using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class DroneInteraction : InteractionBase
{
    public InputActionReference interact;
    public InputActionReference water;

    private Coroutine coroutineWater;
    private Coroutine coroutinePlant;
    public static DroneInteraction instance;

    private void Start()
    {
        instance = this;

    }
    private void OnEnable()
    {
        interact.action.canceled += FinishPlanting;
        interact.action.performed += CommencePlanting;
        water.action.canceled += FinishWatering;
        water.action.performed += CommenceWatering;
    }

    private void CommencePlanting(InputAction.CallbackContext callbackContext)
    {
        coroutinePlant = StartCoroutine(PlantPlot());
    }
    private void CommenceWatering(InputAction.CallbackContext callbackContext)
    {
        coroutineWater = StartCoroutine(WAterPlot());
    }

    private void FinishPlanting(InputAction.CallbackContext callbackContext)
    {
        if (coroutinePlant != null)
        {
            StopCoroutine(coroutinePlant);
            coroutinePlant = null;
        }
    }

    private void FinishWatering(InputAction.CallbackContext callbackContext)
    {
        if (coroutineWater != null)
        {
            StopCoroutine(coroutineWater);
            coroutineWater = null;
        }
    }


    private void OnDisable()
    {
        if (coroutineWater != null)
        {
            StopCoroutine(coroutineWater);
            coroutineWater = null;
        }
        if (coroutinePlant != null)
        {
            StopCoroutine(coroutinePlant);
            coroutinePlant = null;
        }
        interact.action.canceled -= FinishPlanting;
        interact.action.performed -= CommencePlanting;
        water.action.canceled -= FinishWatering;
        water.action.performed -= CommenceWatering;
    }
    public IEnumerator WAterPlot()
    {
        while (true)
        {
            yield return new WaitForEndOfFrame();
            LaunchRayWater(InventairePerso.instance);
        }
    }
    public IEnumerator PlantPlot()
    {
        while (true)
        {
            yield return new WaitForEndOfFrame();
            LaunchRayInteract(InventairePerso.instance);
        }
    }
}
