using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour {
    private Timer timer;
    private Interactable linkedInteractable;
    [SerializeField] private Image progressBar;
    private Camera mainCam;
    private RectTransform rectTransform;
    [SerializeField] private Vector3 offset;
    
    public void SetProgressBar(Timer newTimer, Interactable newLinkedInteractable, Vector3 cameraOffset) {
        timer = newTimer;
        rectTransform = GetComponent<RectTransform>();
        mainCam = GameObject.Find("Camera").GetComponent<Camera>();
        linkedInteractable = newLinkedInteractable;
        offset = cameraOffset;
    }

    public void SetProgressBar(Timer newTimer, Interactable newLinkedInteractable) {
        SetProgressBar(newTimer, newLinkedInteractable, offset);
    }

    void Update() {
        //Updating position
        rectTransform.position = mainCam.WorldToScreenPoint(linkedInteractable.transform.position) + offset; 
        // Fill Amount
        float percentComplete= (Time.time - timer.startTime)/ timer.duration;
        progressBar.fillAmount = percentComplete;
        if(percentComplete >= 1)
            Destroy(gameObject);
    }
}
