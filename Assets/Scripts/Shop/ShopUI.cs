using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[System.Serializable]
public class ShopItem
{
    public ItemData item;
    public int price;
    public bool useGem; // true면 Gem, false면 Gold로 구매
}

public class ShopUI : MonoBehaviour
{
    public ShopItem[] shopItems;

    public Transform slotParent;
    public GameObject shopSlotPrefab;

    [Header("Gem -> Gold 환전")]
    public int goldPerGem = 100;
    public TMP_Text exchangeInfoText;

    private void OnEnable()
    {
        Refresh();
        if (exchangeInfoText != null)
            exchangeInfoText.text = $"1 Gem = {goldPerGem} Gold";
    }

    public void Refresh()
    {
        foreach (Transform child in slotParent)
            Destroy(child.gameObject);

        foreach (var shopItem in shopItems)
        {
            GameObject obj = Instantiate(shopSlotPrefab, slotParent);
            var ui = obj.GetComponent<ShopSlotUI>();
            ui.Setup(shopItem);
        }
    }

    public void OnClickExchangeGemToGold()
    {
        if (CurrencyManager.Instance.gem <= 0) return;

        CurrencyManager.Instance.gem--;
        CurrencyManager.Instance.gold += goldPerGem;
    }

    public void OnClickClose()
    {
        UIManager.Instance.ShowDefault();
    }
}