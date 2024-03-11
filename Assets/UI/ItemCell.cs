using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemCell : MonoBehaviour {
    private Item item;
    private uint count;

    [SerializeField] private Image itemSprite;
    [SerializeField] private TextMeshProUGUI itemCount;

    public void SetItem(Item newItem, uint newCount) {
        item = newItem;
        count = newCount;
        if (newCount == 0) {
            itemSprite.enabled = false;
            itemCount.enabled = false;
            item = null;
            return;
        }
        itemSprite.enabled = true;
        itemCount.enabled = true;
        itemSprite.sprite = newItem.itemSprite;
        itemCount.SetText(newCount.ToString());
    }

    public Item GetItem() {
        return item;
    }

    public uint GetCount() {
        return count;
    }
}   
