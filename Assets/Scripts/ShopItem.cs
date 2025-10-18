using UnityEngine;

public class ShopItem : MonoBehaviour
{
    private int price;
    public void BuyItem()
    {
        PorteMonnaie.instance.RemoveMoney(price);
    }

    public void setPrice(int price)
    {
        this.price = price;
    }

    public int getPrice()
    {
        return this.price;
    }
}
