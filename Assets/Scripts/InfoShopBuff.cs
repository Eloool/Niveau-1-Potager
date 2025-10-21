using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "InfoBuff", menuName = "Shop/InfoBuff")]
public class InfoShopBuff : ScriptableObject
{
    public List<int> infos;
    public List<int> price;
}

