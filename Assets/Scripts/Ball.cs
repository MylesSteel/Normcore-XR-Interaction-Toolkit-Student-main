using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;
using UnityEngine.XR.Interaction.Toolkit;

public class Ball : MonoBehaviour
{
    public RealtimeTransform _rtTrandsform;
    public XRGrabInteractable _xrGrab;

    private void Update()
    {
        if (_rtTrandsform.isOwnedRemotelyInHierarchy)
        {
            _xrGrab.enabled = false;
            _xrGrab.enabled = true; 
        }
    }





}
