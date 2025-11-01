using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BlueprintPlantation : MonoBehaviour
{
    public static BlueprintPlantation Instance;
    private bool isInBlueprint =false;
    public GameObject blueprintText;

    public InputActionReference inputBlueprint;
    public Material materialBlueprint;

    private void Awake()
    {
        Instance = this;
    }

    private void OnEnable()
    {
        inputBlueprint.action.performed += ChangeMode;
    }

    public void ChangeMode(InputAction.CallbackContext callbackContext)
    {
        isInBlueprint = !isInBlueprint;
        foreach(List<PlotJardin> plotJardins in Jardin.instance.getAllPlots())
        {
            foreach(PlotJardin plotJardin in plotJardins)
            {
                plotJardin.ChangeVuePlant(isInBlueprint);
            }
        }
        blueprintText.SetActive(isInBlueprint);

    }

    private void OnDisable()
    {
        inputBlueprint.action.performed -= ChangeMode;
    }

    public bool getMode()
    {
        return isInBlueprint;
    }
}
