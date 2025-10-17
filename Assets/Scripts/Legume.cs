using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Legume 
{
    private PlotJardin plotJardin;
    private LegumeInfo info;
    public GameObject legumeObject;
    public StadeLegume stadeLegume;
    private int timeStadeLegume =0;
    private float currentTimeBeforeExplosion = 0f;

    public void LoadInfo(LegumeInfo info)
    {
        this.info = info;
        stadeLegume = StadeLegume.avantmur;
    }

    public IEnumerator UpdateLegume()
    {
        if (plotJardin.isPlotWatered())
        {
            while (timeStadeLegume != info.stadeLegumeTimes.Count)
            {
                Debug.Log(timeStadeLegume);
                yield return new WaitForSeconds(info.stadeLegumeTimes[timeStadeLegume].time);
                
                plotJardin.UpdateLegume();
                timeStadeLegume++;

            }
            stadeLegume = StadeLegume.mur;
            while (currentTimeBeforeExplosion < info.TimeBeforeExplosion)
            {
                yield return new WaitForSeconds(1f);
                legumeObject.transform.localScale += Vector3.one * 0.01f;
                currentTimeBeforeExplosion += 1f;
            }
            plotJardin.RemoveLegumeFromPlot();
            yield return null;
        }
    }

    public void setPlotJardin(PlotJardin plotJardin)
    {
        this.plotJardin = plotJardin;
    }
    
    public GameObject getCurrentStadeLegumeObject()
    {
        return info.stadeLegumeTimes[timeStadeLegume].stadeLegume;
    }

    public void LegumeGotten()
    {
        Score.instance.addScore(info.ScoreGiven);
        PorteMonnaie.instance.addMoney(info.MoneyGiven);
        plotJardin.RemoveLegumeFromPlot();
    }

}
public enum StadeLegume
{
    avantmur
    ,mur
}