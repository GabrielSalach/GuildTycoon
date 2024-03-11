using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Just a GameObject container for an inventory for now
public class Chest : MonoBehaviour {
    [SerializeField] private Inventory inventory;
    public Inventory Inventory => inventory;
}
