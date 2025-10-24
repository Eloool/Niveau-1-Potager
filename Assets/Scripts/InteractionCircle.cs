using UnityEngine;

public class InteractionCircle : MonoBehaviour
{
    public GameObject circleSelectionPrefab;
    private GameObject circleSelection;
    public LayerMask maskTarget;
    private PlotJardin lastPlotJardin;

    private void Awake()
    {
        circleSelection = Instantiate(circleSelectionPrefab);
        circleSelection.SetActive(false);
    }


    private void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down * 10), out hit, Mathf.Infinity, maskTarget))
        {
            PlotJardin plotJardin;
            if (hit.transform.gameObject.TryGetComponent<PlotJardin>(out plotJardin))
            {
                if (lastPlotJardin != plotJardin)
                {
                    if (!lastPlotJardin)
                    {
                        circleSelection.SetActive(true);
                    }
                    circleSelection.transform.position = new Vector3(plotJardin.transform.position.x, plotJardin.transform.position.y + 2f, plotJardin.transform.position.z);
                    lastPlotJardin = plotJardin;
                }
            }
            else
            {
                if (lastPlotJardin)
                {
                    circleSelection.SetActive(false);
                    lastPlotJardin = null;
                }
            }
        }
    }
}
