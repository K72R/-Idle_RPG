using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopSlotUI : MonoBehaviour
{
    public Image icon;
    public TMP_Text nameText;
    public TMP_Text priceText;
    public TMP_Text currencyText;

    private ShopItem data;

    public void Setup(ShopItem item)
    {
        data = item;

        icon.sprite = item.item.icon;
        nameText.text = item.item.itemName;
        priceText.text = item.price.ToString();
        currencyText.text = item.useGem ? "Gem" : "Gold";
    }

    public void OnClickBuy()
    {
        var cur = CurrencyManager.Instance;

        if (data.useGem)
        {
            if (cur.gem >= data.price)
            {
                cur.gem -= data.price;
                InventoryManager.Instance.AddItem(data.item);
            }
            else
            {
                Debug.Log("젬 부족");
            }
        }
        else
        {
            if (cur.gold >= data.price)
            {
                cur.gold -= data.price;
                InventoryManager.Instance.AddItem(data.item);
            }
            else
            {
                Debug.Log("골드 부족");
            }
        }
    }
}
