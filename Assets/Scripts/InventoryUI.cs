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
            obj.GetComponent<ItemSlotUI>().Setup(slot);
        }
    }
}
