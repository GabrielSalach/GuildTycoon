using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;
using UnityEngine.UI;

public class Cursor : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    private Vector2 cursorPos;
    private GraphicRaycaster raycaster;


    public void OnCursorMove(InputAction.CallbackContext context)
    {
        cursorPos = context.ReadValue<Vector2>();
    }

    /// <summary>
    /// Handles the cursor click on interactables
    /// </summary>
    public void OnClick(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        Ray ray = mainCamera.ScreenPointToRay(cursorPos);
        RaycastHit hit;
        if (!Physics.Raycast(ray, out hit, Mathf.Infinity)) return;
        Interactable interactable = hit.transform.GetComponent<Interactable>();
        if (interactable != null)
        {
            IInputInteraction interaction = context.interaction;
            switch (interaction)
            {
                case PressInteraction:
                    interactable.OnClick();
                    break;
                case MultiTapInteraction:
                    interactable.OnDoubleClick();
                    break;
                case HoldInteraction:
                    interactable.OnHold();
                    break;
                default:
                    Debug.Log("Error");
                    break;
            }
        }
        else
        {
            Interactable.OnUnfocus();
        }
    }
}
