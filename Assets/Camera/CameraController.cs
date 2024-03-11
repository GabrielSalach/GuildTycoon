using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float panSpeed, rotateSpeed, zoomSpeed, zoomMinDistance, zoomMaxDistance;
    [SerializeField] private GameObject cameraTarget;
    [SerializeField] private CinemachineFreeLook virtualCam;

    private Vector3 movementVector;
    private float angle;
    private Vector3 rotatedVector;
    private float zoomInput;
    private float zoomDistance;

    private void Start()
    {
        zoomDistance = zoomMaxDistance;
        UpdateZoom();
    }
    
    public void MoveCamera(InputAction.CallbackContext context)
    {
        Vector2 moveInput = context.ReadValue<Vector2>();
        movementVector = new Vector3(moveInput.x, 0, moveInput.y);
    }

    public void ZoomControl(InputAction.CallbackContext context)
    {
        zoomInput = context.ReadValue<float>();
        UpdateZoom();
    }

    private void UpdateZoom()
    {
        //Updates zoom distance
        zoomDistance = Mathf.Clamp(zoomDistance + (-zoomInput * zoomSpeed), zoomMinDistance, zoomMaxDistance);
        //Updates Height
        virtualCam.m_Orbits[0].m_Height = virtualCam.m_Orbits[2].m_Height + zoomDistance;
        virtualCam.m_Orbits[1].m_Height = virtualCam.m_Orbits[2].m_Height + zoomDistance / 2;
        //Updates Radii
        virtualCam.m_Orbits[2].m_Radius = zoomDistance;
        virtualCam.m_Orbits[1].m_Radius = Mathf.Sqrt(Mathf.Pow(zoomDistance, 2) - Mathf.Pow(zoomDistance / 2, 2));
    }

    private void UpdateRotation()
    {
        Vector3 vCamPosition = virtualCam.transform.position;
        Vector3 vCamGroundPos = new Vector3(vCamPosition.x, 0, vCamPosition.z);
        Vector3 targetPos = cameraTarget.transform.position;
        Vector3 targetGroundPos = new Vector3(targetPos.x, 0, targetPos.z);
        Vector3 directionVector = targetGroundPos - vCamGroundPos;
        directionVector.Normalize();
        angle = Vector3.SignedAngle(Vector3.forward, directionVector, Vector3.up);
    }
    private void Update()
    { 
        UpdateRotation();
        rotatedVector = Quaternion.AngleAxis(angle, Vector3.up) * movementVector;
        cameraTarget.transform.position += rotatedVector * (panSpeed * Time.deltaTime);
    }
}
