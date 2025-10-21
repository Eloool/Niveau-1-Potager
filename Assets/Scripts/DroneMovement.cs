using UnityEngine;
using UnityEngine.InputSystem;

public class DroneMovement : MonoBehaviour
{
    public InputActionReference actionReference;
    public float speed;
    private CharacterController characterController;
    public static DroneMovement instance;

    private void Awake()
    {
        instance = this;
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Vector2 deplac = actionReference.action.ReadValue<Vector2>();
        Vector3 deplacement3d = new Vector3(deplac.x,0,deplac.y);
        characterController.Move(deplacement3d * Time.deltaTime *speed);
    }
}
