using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shop : MonoBehaviour
{
    private List<ShopItem> ShopItems = new List<ShopItem>();
    public List<ShopItemScriptable> shopItemScriptables = new List<ShopItemScriptable>();
    public GameObject shopItemPrefab;
    public Transform shopTransform;
    public GameObject shop;
    public InputActionReference shopActionReference;

    private void Start()
    {
        foreach (ShopItemScriptable shopItem in shopItemScriptables)
        {
            GameObject shopitem = Instantiate(shopItemPrefab, shopTransform);
            ShopItems.Add(shopitem.GetComponent<ShopItem>());
            CreateBuff(shopitem, shopItem.classBuff);
            ShopItems[ShopItems.Count - 1].LoadInfo(shopItem);
        }
        UpdateAllShopItems();
    }

    private void OnEnable()
    {
        shopActionReference.action.performed += ChangeShopInput;
    }

    private void CreateBuff(GameObject gameObject, ClassBuff classBuff)
    {
        switch (classBuff)
        {
            case ClassBuff.Multiplication:
                gameObject.AddComponent<MultiplicateurScore>(); break;
            case ClassBuff.AjoutDrone:
                gameObject.AddComponent<ActivationDrone>();
                break;
            case ClassBuff.AugmentationArrosoir:
                gameObject.AddComponent<AugmentMaxSizeArrosoir>();
                break;
            case ClassBuff.AugmentationSeeds:
                gameObject.AddComponent<AugmentionMaxInventaire>(); break;
            default:
                break;
        }
    }

    public void UpdateAllShopItems()
    {
        foreach (ShopItem shopItem in ShopItems)
        {
            shopItem.UpdateShopItem();
        }
    }

    public void ChangeShopInput(InputAction.CallbackContext callbackContext)
    {
        if (shop.activeInHierarchy)
        {
            shop.SetActive(false);
            MenusManager.instance.RemoveCanvas(shop);
        }
        else
        {
            if (MenusManager.instance.OpenCanvas(shop))
            {
                shop.SetActive(true);
            }
        }
    }

    public void CloseShopButton()
    {
        shop.SetActive(false);
        MenusManager.instance.RemoveCanvas(shop);

    }

    private void OnDisable()
    {
        shopActionReference.action.performed -= ChangeShopInput;
    }
}

public enum ClassBuff
{
    Multiplication,
    AjoutDrone,
    AugmentationArrosoir,
    AugmentationSeeds
}