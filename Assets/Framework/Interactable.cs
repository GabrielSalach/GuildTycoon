using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Outline))]
public class Interactable : MonoBehaviour
{
    private static Interactable focusedInteractable;
    private Outline outline;
    [HideInInspector] public UnityEvent onClick, onDoubleClick, onHold, onFocus, onUnfocus;
    

    public void Awake() {
        outline = GetComponent<Outline>();
        outline.OutlineColor = Color.yellow;
        outline.OutlineWidth = 6;
        outline.enabled = false;
        
        
        // Assign Input Callbacks
        onClick.AddListener(Click);
        onFocus.AddListener(Focus);
        onUnfocus.AddListener(Unfocus);
    }

    // Input Event Callbacks
    public void OnClick() {
        onClick.Invoke();
    }
    public void OnDoubleClick() {
        onDoubleClick.Invoke();
    }
    public void OnHold() {
        onHold.Invoke();
    }
    
    // Internal Callbacks
    private void OnFocus() {
        onFocus.Invoke();
    }
    public static void OnUnfocus() {
        if (focusedInteractable == null)
            return;
        focusedInteractable.onUnfocus.Invoke();
    }
    
    private void Click(){
        OnFocus();
    }

    private void Focus()
    {
        OnUnfocus();
        focusedInteractable = this;
        outline.enabled = true;
    }
    
    private static void Unfocus() {
        if (focusedInteractable == null)
            return;
        focusedInteractable.outline.enabled = false;
        focusedInteractable = null;
    }

    public static GameObject getFocusedInteractable()
    {
        return focusedInteractable.gameObject;
    }
}
