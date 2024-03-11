using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerManager : MonoBehaviour {
    public static TimerManager instance;
    public List<Timer> timers;

    private void Awake() {
        if(instance != null) 
            Destroy(this);
        instance = this;

        timers = new List<Timer>();
    }

    private void Update() {
        if (timers.Count == 0)
            return;
        for (int i = timers.Count - 1; i >= 0; i--) {
            if (timers[i].startTime + timers[i].duration <= Time.time) {
                timers[i].callback();
                timers.RemoveAt(i);
            }
        } 
    }
}
