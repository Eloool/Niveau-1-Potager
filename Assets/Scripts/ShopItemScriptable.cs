using System;
using UnityEngine;

[CreateAssetMenu(fileName = "NewShopItem", menuName = "Shop")]
public class ShopItemScriptable : ScriptableObject
{
    public ClassBuff classBuff;
    public string Title;
    public string Description;
    public Texture sprite;
    public InfoShopBuff info;
}

