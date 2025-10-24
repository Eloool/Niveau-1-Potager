using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jardin : MonoBehaviour
{
    private List<List<PlotJardin>> jardinList =new List<List<PlotJardin>>();
    public List<PanneauLegume> panneauLegumes;
    public Arrosoir arrosoir;
    public static Jardin instance;
    private static LegumeInfo info;
    

    private float multiplcateurEngrais = 1f;

    private void Awake()
    {
        instance = this;
    }

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

    public void setMultiplicateur(float multiplcateur)
    {
        multiplcateurEngrais = multiplcateur;
    }

    public float getMultiplicateur()
    {
        return multiplcateurEngrais;
    }
    public PanneauLegume GetPanneau(LegumeInfo legumeInfo)
    {
        info = legumeInfo;
        return panneauLegumes.Find(IsSameInfo);
    }

    public Arrosoir getArrosoir()
    {
        return arrosoir;
    }

    private static bool IsSameInfo(PanneauLegume legumeInfo)
    {
        return legumeInfo.legumeGiven.Equals(info);
    }

    public List<List<PlotJardin>> getAllPlots()
    {
        return jardinList;
    }

    
}
