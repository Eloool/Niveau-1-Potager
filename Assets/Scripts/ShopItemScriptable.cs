using UnityEngine;

[CreateAssetMenu(fileName = "NewShopItem", menuName = "Shop")]
public class ShopItemScriptable : ScriptableObject
{
    public ShopBuff shopBuff;
    public string Title;
    public string Description;
}
