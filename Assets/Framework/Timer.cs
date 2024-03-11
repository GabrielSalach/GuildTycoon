using UnityEngine;

public class Timer {
    
    public readonly float startTime;
    public readonly float duration;
    public delegate void Callback();
    public readonly Callback callback;

    public Timer(float duration, Callback callback) {
        this.startTime = Time.time;
        this.duration = duration;
        this.callback = callback;
        TimerManager.instance.timers.Add(this);
    }
}