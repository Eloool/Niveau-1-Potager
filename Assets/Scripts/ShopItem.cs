using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour
{
    private int price;
    private ShopItemScriptable itemScriptable;
    public TextMeshProUGUI titre;
    public TextMeshProUGUI description;
    private ShopBuff shopBuff;
    public RawImage image;
    public TextMeshProUGUI priceText;
    public Button button;
    public void BuyItem()
    {
        PorteMonnaie.instance.RemoveMoney(price);
        shopBuff.Activate();
    }
    

    public void LoadInfo(ShopItemScriptable itemScriptable)
    {
        this.itemScriptable = itemScriptable;
        price = itemScriptable.price;
        titre.text = itemScriptable.Title;
        description.text = itemScriptable.Description;
        image.texture = itemScriptable.sprite;
        shopBuff = GetComponent<ShopBuff>();
        priceText.text = "Prix : " + price.ToString();
    }

    public void UpdateShopItem()
    {
        if (price < PorteMonnaie.instance.getMoney())
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
}
