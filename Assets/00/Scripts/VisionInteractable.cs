using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.PolySpatial.InputDevices;
using UnityEngine.InputSystem.EnhancedTouch;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.InputSystem.Utilities;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;
using TouchPhase = UnityEngine.InputSystem.TouchPhase;

/// <summary>
/// 
/// </summary>
public class VisionInteractable : MonoBehaviour
{
    #region Inspector Fields
    #endregion


    #region Public Properties
    #endregion


    #region Events
    public event Action<SpatialPointerState> OnIndirectPinch;
    public event Action<SpatialPointerState> OnTouch;
    public event Action<SpatialPointerState> OnDirectPinch;
    public event Action<SpatialPointerState> OnPointer;
    #endregion


    #region Internal Variables
    #endregion


    #region Data Constructs
    #endregion


    #region MonoBehaviour Loop
    private void Awake()
    {
        
    }
    #endregion
    
    
    #region Event Handlers
    #endregion
    

    #region Internal Functions
    internal void HandleOnIndirectPinch(SpatialPointerState touchData)
    {
        OnIndirectPinch?.Invoke(touchData);
    }
    internal void HandleOnTouch(SpatialPointerState touchData)
    {
        OnTouch?.Invoke(touchData);
    }
    internal void HandleOnDirectPinch(SpatialPointerState touchData)
    {
        OnDirectPinch?.Invoke(touchData);
    }
    internal void HandleOnPointer(SpatialPointerState touchData)
    {
        OnPointer?.Invoke(touchData);
    }
    #endregion


    #region Public API
    #endregion
}
