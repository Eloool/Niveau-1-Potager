using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    private List<ShopItem> ShopItems = new List<ShopItem>();
    public List<ShopItemScriptable> shopItemScriptables = new List<ShopItemScriptable>();
    public GameObject shopItemPrefab;
    public Transform shopTransform;
    public GameObject shop;
    public Scrollbar scrollbar;
    public InputActionReference shopActionReference;
    public static Shop instance;
    private static ShopItem shopItemtemp;

    private void Start()
    {
        instance = this;
        foreach (ShopItemScriptable shopItem in shopItemScriptables)
        {
            GameObject shopitem = Instantiate(shopItemPrefab, shopTransform);
            ShopItems.Add(shopitem.GetComponent<ShopItem>());
            CreateBuff(shopitem, shopItem.classBuff);
            ShopItems[ShopItems.Count - 1].LoadInfo(shopItem);
        }
        UpdateAllShopItems();
        shop.SetActive(true);
        shop.SetActive(false);

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
                gameObject.AddComponent<ActivationDrone>(); break;
            case ClassBuff.AugmentationArrosoir:
                gameObject.AddComponent<AugmentMaxSizeArrosoir>(); break;
            case ClassBuff.AugmentationSeeds:
                gameObject.AddComponent<AugmentionMaxInventaire>(); break;
            case ClassBuff.AugmenationVitessePousse:
                gameObject.AddComponent<AugmentationVitessePousse>(); break;
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
            CloseShopButton();
        }
        else
        {
            if (MenusManager.instance.OpenCanvas(shop))
            {
                shop.SetActive(true);
                scrollbar.value = 1;
                Score.instance.gameObject.SetActive(false);
                InventaireCanvas.instance.transform.parent.gameObject.SetActive(false);
                EventSystem.current.firstSelectedGameObject = ShopItems[0].button.gameObject;
                EventSystem.current.SetSelectedGameObject(ShopItems[0].button.gameObject);
                foreach (ShopItem shopItem in ShopItems)
                {
                    shopItem.UpdateButton();
                }
            }
        }
    }

    public int getInfoForBuff(ShopItem shopItem , int index)
    {
        shopItemtemp = shopItem;
        int indexList = ShopItems.FindIndex(findIndex);
        return shopItemScriptables[indexList].info.infos[index];
    }

    public void UpdateShopItem(ShopItem shopItem ,int index)
    {
        shopItemtemp = shopItem;
        int indexList = ShopItems.FindIndex(findIndex);
        if (index < shopItemScriptables[indexList].info.price.Count)
        {
            shopItem.setPrice(shopItemScriptables[indexList].info.price[index]);
        }
        else
        {
            shopItemScriptables.Remove(shopItemScriptables[indexList]);
            ShopItems.Remove(shopItem);
            Destroy(shopItem.gameObject);
            EventSystem.current.firstSelectedGameObject = ShopItems[0].button.gameObject;
            EventSystem.current.SetSelectedGameObject(ShopItems[0].button.gameObject);
        }
    }

    public static bool findIndex(ShopItem shopItem)
    {
        return shopItem.Equals(shopItemtemp);
    }

    public void CloseShopButton()
    {
        shop.SetActive(false);
        MenusManager.instance.RemoveCanvas(shop);
        Score.instance.gameObject.SetActive(true);
        InventaireCanvas.instance.transform.parent.gameObject.SetActive(true);
        EventSystem.current.firstSelectedGameObject = null;
        EventSystem.current.SetSelectedGameObject(null);
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
    AugmentationSeeds,
    AugmenationVitessePousse
}