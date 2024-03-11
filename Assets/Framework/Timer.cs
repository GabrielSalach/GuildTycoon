using UnityEngine;

public class Timer {
    
    public readonly float startTime;
    public readonly float duration;
    public delegate void Callback();
    public readonly Callback callback;

    /// <summary>
    /// Creates a new Timer and calls the callback when it's over
    /// </summary>
    /// <param name="duration">Duration of the timer in seconds</param>
    /// <param name="callback">void parameter-less function to call</param>
    public Timer(float duration, Callback callback) {
        this.startTime = Time.time;
        this.duration = duration;
        this.callback = callback;
        TimerManager.instance.timers.Add(this);
    }
}