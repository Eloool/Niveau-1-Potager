using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Jardin : MonoBehaviour
{
    private List<List<PlotJardin>> jardinList =new List<List<PlotJardin>>();

    private void Start()
    {
        PlotJardin[] list = GetComponentsInChildren<PlotJardin>();
        int cpt = 0 , row =0;
        for (int i = 0; i < list.Length; i++)
        {
            if(cpt == 0)
            {
                List<PlotJardin> plotJardinsrow = new List<PlotJardin>();
                jardinList.Add(plotJardinsrow);
            }

            jardinList[jardinList.Count - 1].Add(list[i]);

            if (cpt == 20)
            {
                jardinList[jardinList.Count - 1].Sort(delegate (PlotJardin x, PlotJardin y)
                {
                    return x.transform.position.x.CompareTo( y.transform.position.x);
                }); 
                row++;
            }
            cpt++;
            if (cpt == 21)
                cpt=0 ;
        }
    }
}
