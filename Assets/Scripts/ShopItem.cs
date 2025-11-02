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
    private int indexPrice = 0;
    public GameObject textBuy;
    public void BuyItem()
    {
        PorteMonnaie.instance.RemoveMoney(price);
        shopBuff.Activate(Shop.instance.getInfoForBuff(this, indexPrice));
        indexPrice++;
        Shop.instance.UpdateShopItem(this, indexPrice);
    }

    public void LoadInfo(ShopItemScriptable itemScriptable)
    {
        titre.text = itemScriptable.Title;
        description.text = itemScriptable.Description;
        image.texture = itemScriptable.sprite;
        shopBuff = GetComponent<ShopBuff>();
        UpdateShopItem();
        Shop.instance.UpdateShopItem(this, indexPrice);
    }

    public void UpdateShopItem()
    {
        priceText.text = "Prix : " + price.ToString();
        UpdateButton();
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

    public void UpdateButton()
    {
        if (price <= PorteMonnaie.instance.getMoney())
        {
            button.interactable = true;
            button.GetComponent<RawImage>().texture = Resources.Load<Texture>("button_grey");
            textBuy.SetActive(true);
        }
        else
        {
            button.interactable = false;
            button.GetComponent<RawImage>().texture = Resources.Load<Texture>("button_grey_close");
            textBuy.SetActive(false);
        }
    }
}
