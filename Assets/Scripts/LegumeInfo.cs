using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewLegume", menuName = "Legume")]
public class LegumeInfo : ScriptableObject
{
    public string nom;
    public List<StadeLegumeTime> stadeLegumeTimes;
    public float TimeBeforeExplosion;
    public int ScoreGiven;
    public int MoneyGiven;
}

[Serializable]
public class StadeLegumeTime
{
    public GameObject stadeLegume;
    public float time;
}
