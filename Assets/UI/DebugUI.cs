using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DebugUI : Window
{
    public static DebugUI instance;
    [SerializeField] private List<TextMeshProUGUI> debugSlots;

    protected override void Init() {
        base.Init();
        if (instance != null)
           Destroy(this);
        instance = this;
        
        isOpened = true;
        SetTitle("Debug");
    }

    public void SetText(int slotIndex, string text) {
        debugSlots[slotIndex].SetText(text);
    }

}
