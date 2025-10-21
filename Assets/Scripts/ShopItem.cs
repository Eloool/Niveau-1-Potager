using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour
{
    private int price;
    public TextMeshProUGUI titre;
    public TextMeshProUGUI description;
    private ShopBuff shopBuff;
    public RawImage image;
    public TextMeshProUGUI priceText;
    public Button button;
    private int indexPrice =0;
    public void BuyItem()
    {
        PorteMonnaie.instance.RemoveMoney(price);
        shopBuff.Activate(Shop.instance.getInfoForBuff(this,indexPrice));
        indexPrice++;
        Shop.instance.UpdateShopItem(this,indexPrice);
    }

    public void LoadInfo(ShopItemScriptable itemScriptable)
    {
        titre.text = itemScriptable.Title;
        description.text = itemScriptable.Description;
        image.texture = itemScriptable.sprite;
        shopBuff = GetComponent<ShopBuff>();
        UpdateShopItem();
        Shop.instance.UpdateShopItem(this,  indexPrice);
    }

    public void UpdateShopItem()
    {
        priceText.text = "Prix : " + price.ToString();
        if (price <= PorteMonnaie.instance.getMoney())
        {
            button.interactable = true;
        }
        else
        {
            button.interactable=false;
        }
    }
    public int getPrice()
    {
        return this.price;
    }
    public void setPrice(int price)
    {
        this.price = price;
        UpdateShopItem();
    }
}
