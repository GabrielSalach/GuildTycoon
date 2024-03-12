using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// Base class for all windows
/// </summary>
public class Window : MonoBehaviour {
    // Targets to be moved to 
    [SerializeField] private RectTransform openedTarget, closedTarget;

    // Animation stuff for tweening between targets
    [SerializeField] private AnimationCurve animationCurve;
    [SerializeField] private float animationSpeed;

    // UI Elements
    [SerializeField] private RectTransform windowRectTransform;
    [SerializeField] private RectTransform background;
    [SerializeField] private TextMeshProUGUI title;
    [SerializeField] private Button closeButton;

    private void Awake() {
        Init();
        
        closeButton.onClick.AddListener(CloseWindow);
    }

    /// <summary>
    /// Initializes window flags. Can be overriden. 
    /// </summary>
    protected virtual void Init() {
        isOpened = false;
        isMoving = false;
        isLocked = true;
        isFocused = false;
    }
    
    // States flags
    protected bool isOpened, isMoving, isLocked, isFocused;
    
    /// <summary>
    /// Tweens the window position between from to to 
    /// </summary>
    /// <param name="from">Beginning position</param>
    /// <param name="to">End position</param>
    private void Animate(Vector3 from, Vector3 to) {
        windowRectTransform.position = to;
    }

    /// <summary>
    /// Sets the title of the window
    /// </summary>
    /// <param name="newTitle">New title</param>
    protected void SetTitle(string newTitle) {
        title.SetText(newTitle);
    }
    
    /// <summary>
    /// Opens the window
    /// </summary>
    public void OpenWindow() {
        if(isOpened && !isLocked)
            return;
        isOpened = true;
        isFocused = true;
        Animate(closedTarget.position, openedTarget.position);
    }

    /// <summary>
    /// Closes the window
    /// </summary>
    public void CloseWindow() {
        if (!isOpened && isLocked)
            return;
        isOpened = false;
        isFocused = false;
        Animate(openedTarget.position, closedTarget.position);
    }
    
    /// <summary>
    /// Moves the window using the mouse but it doesn't work yet.
    /// </summary>
    /// <param name="mousePos"></param>
    public void MoveWindow(Vector2 mousePos) {
        if (isLocked)
            return;
        Vector3 windowPos = windowRectTransform.position;
        Vector3 relativeMousePos = windowPos - (Vector3) mousePos;
        windowPos += relativeMousePos;
        windowRectTransform.position = windowPos;
    }
}
