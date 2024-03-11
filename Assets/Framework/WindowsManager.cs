using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Just a list of useful windows for now 
/// </summary>
public class WindowsManager : MonoBehaviour {
    public static WindowsManager instance;
    public WorkerWindow WorkerWindow;

    void Awake() {
        if (instance != null) {
            Destroy(this);
            return;
        }
        instance = this;
    }
    
}
