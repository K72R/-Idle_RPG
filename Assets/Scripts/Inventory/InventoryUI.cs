using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Transform slotParent;
    public GameObject slotPrefab;

    private void OnEnable()
    {
        Refresh();
    }

    public void Refresh()
    {
        foreach (Transform child in slotParent)
            Destroy(child.gameObject);

        foreach (var slot in InventoryManager.Instance.items)
        {
            GameObject obj = Instantiate(slotPrefab, slotParent);
            var ui = obj.GetComponent<ItemSlotUI>();
            ui.Setup(slot);
        }

        int emptyCount = InventoryManager.Instance.maxSlots - InventoryManager.Instance.items.Count;
        for (int i = 0; i < emptyCount; i++)
        {
            Instantiate(slotPrefab, slotParent); // 아이템 없는 빈 슬롯
        }
    }

    public void OnClickClose()
    {
        UIManager.Instance.ShowDefault();
    }
}
