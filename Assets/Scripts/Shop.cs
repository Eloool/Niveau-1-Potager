using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    private List<ShopItem> ShopItems =new List<ShopItem>();



    private void Start()
    {
        
    }
    private void addShopItem(ShopItem item)
    {
        ShopItems.Add(item);
    }

    private void removeShopItem(ShopItem item) { ShopItems.Remove(item); }
}
