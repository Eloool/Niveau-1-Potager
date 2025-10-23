using UnityEngine;

public class Interaction : MonoBehaviour
{
    public virtual void Interact(Inventaire inventaire)
    {
        Debug.Log("Function not done");
    }

    public virtual void Water(Inventaire inventaire)
    {
        Debug.Log("You can't water this");
    }
}
