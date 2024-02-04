using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// </summary>
public class LinkedItemField : MonoBehaviour
{
    #region Inspector Fields
    [SerializeField] private LinkedItem _linkedItem;
    #endregion


    #region Public Properties
    #endregion


    #region Events
    #endregion


    #region Internal Variables
    private Transform _transform;
    #endregion


    #region Data Constructs
    #endregion


    #region MonoBehaviour Loop
    private void Awake()
    {
        _transform = transform;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out LinkedItem linkedItem))
        {
            linkedItem.SetEndState(_transform.position);
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
