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
public class VisionInputManager : MonoBehaviour
{
    #region Inspector Fields
    #endregion


    #region Public Properties
    #endregion


    #region Events
    #endregion


    #region Internal Variables
    #endregion


    #region Data Constructs
    #endregion


    #region MonoBehaviour Loop
    private void Awake()
    {
        EnhancedTouchSupport.Enable();
    }
    private void Update()
    {
        ReadOnlyArray<Touch> activeTouches = Touch.activeTouches;
        
        if (activeTouches.Count <= 0) return;
        
        SpatialPointerState primaryTouchData = EnhancedSpatialPointerSupport.GetPointerState(activeTouches[0]);
        if (activeTouches[0].phase != TouchPhase.Began) return;

        VisionInteractable interactable = null;
        
        switch (primaryTouchData.Kind)
        {
            case SpatialPointerKind.IndirectPinch:
                if (primaryTouchData.targetObject.TryGetComponent(out interactable)) interactable.HandleOnIndirectPinch(primaryTouchData);
                break;
            
            case SpatialPointerKind.Touch:
                if (primaryTouchData.targetObject.TryGetComponent(out interactable)) interactable.HandleOnTouch(primaryTouchData);
                break;

            case SpatialPointerKind.DirectPinch:
                if (primaryTouchData.targetObject.TryGetComponent(out interactable)) interactable.HandleOnDirectPinch(primaryTouchData);
                break;
            
            case SpatialPointerKind.Pointer:
                if (primaryTouchData.targetObject.TryGetComponent(out interactable)) interactable.HandleOnPointer(primaryTouchData);
                break;
            
            case SpatialPointerKind.Stylus:
                break;
        }
    }
    #endregion
    
    
    #region Event Handlers
    #endregion
    

    #region Internal Functions
    #endregion


    #region Public API
    #endregion
}
