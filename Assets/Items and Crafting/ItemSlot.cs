using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ItemSlot {
    public Item item;
    public uint count;

    public ItemSlot(Item item, uint count) {
        this.item = item;
        this.count = count;
    } 
}
