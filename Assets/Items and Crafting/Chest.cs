using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour {
    [SerializeField] private Inventory inventory;
    public Inventory Inventory => inventory;
}