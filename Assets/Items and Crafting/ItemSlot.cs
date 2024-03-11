using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// <para>Just a class that contains an Item and a count for said item.</para>
/// <para>Like Pair&lt;Item, Key&gt; but Serializable in the editor</para>
/// </summary>
[Serializable]
public class ItemSlot {
    public Item item;
    public uint count;
    
    public ItemSlot(Item item, uint count) {
        this.item = item;
        this.count = count;
    } 
}
