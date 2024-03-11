using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class Window : MonoBehaviour {
    [SerializeField] private RectTransform openedTarget, closedTarget;
    [SerializeField] private AnimationCurve animationCurve;
    [SerializeField] private float animationSpeed;

    [SerializeField] private RectTransform windowRectTransform;
    [SerializeField] private RectTransform background;
    [SerializeField] private TextMeshProUGUI title;
    [SerializeField] private Button closeButton;

    private void Awake() {
        Init();
        
        closeButton.onClick.AddListener(CloseWindow);
    }

    protected virtual void Init() {
        isOpened = false;
        isMoving = false;
        isLocked = true;
        isFocused = false;
    }
    
    // States flags
    protected bool isOpened, isMoving, isLocked, isFocused;
    
    private void Animate(Vector3 from, Vector3 to) {
        windowRectTransform.position = to;
    }

    protected void SetTitle(string newTitle) {
        title.SetText(newTitle);
    }
    
    public void OpenWindow() {
        if(isOpened && !isLocked)
            return;
        isOpened = true;
        isFocused = true;
        Animate(closedTarget.position, openedTarget.position);
    }

    public void CloseWindow() {
        if (!isOpened && isLocked)
            return;
        isOpened = false;
        isFocused = false;
        Animate(openedTarget.position, closedTarget.position);
    }

    public void MoveWindow(Vector2 mousePos) {
        if (isLocked)
            return;
        Vector3 windowPos = windowRectTransform.position;
        Vector3 relativeMousePos = windowPos - (Vector3) mousePos;
        windowPos += relativeMousePos;
        windowRectTransform.position = windowPos;
    }
}
