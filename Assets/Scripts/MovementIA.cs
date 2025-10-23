using System.Collections;
using UnityEngine;

public class MovementIA : MonoBehaviour
{
    private DroneIA drone;
    private CharacterController controllerDrone;
    public float speed =1f;
    private void Start()
    {
        controllerDrone = GetComponent<CharacterController>();
        drone = GetComponent<DroneIA>();
    }

    public IEnumerator Move()
    {
        yield return null;
        int cpt = 0;
        Vector3 nextMove = Vector3.one;
        while (cpt < drone.route.Count-1)
        {
            nextMove = drone.route[cpt];
            while (Vector3.Distance(transform.position, nextMove) > 0.3f)
            {
                Vector3 MovePas = Vector3.MoveTowards(transform.position,nextMove, speed * Time.deltaTime);
                controllerDrone.Move(MovePas - transform.position);
                yield return null;
            }
            cpt++;
            drone.AfterMoving(cpt);
        }
        nextMove = drone.route[drone.route.Count-1];
        drone.FinishTask();
        while (Vector3.Distance(transform.position, nextMove) > 0.3f)
        {
            Vector3 MovePas = Vector3.MoveTowards(transform.position, nextMove, speed * Time.deltaTime);
            controllerDrone.Move(MovePas - transform.position);
            yield return null;
        }
    }

}
