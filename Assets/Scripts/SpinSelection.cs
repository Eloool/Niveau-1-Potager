using UnityEngine;

public class SpinSelection : MonoBehaviour
{
    public float speedSpin;

    private void Update()
    {
        transform.Rotate(0f, speedSpin * Time.deltaTime, 0f);
    }
}
