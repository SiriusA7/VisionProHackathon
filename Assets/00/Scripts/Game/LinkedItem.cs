using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// </summary>
public class LinkedItem : MonoBehaviour
{
    #region Inspector Fields
    [SerializeField] private float _endScale = 0.07f;
    [SerializeField] private Vector3 _endRotation;
    #endregion


    #region Public Properties
    #endregion


    #region Events
    #endregion


    #region Internal Variables
    private Transform _transform;
    private Collider _collider;
    private Rigidbody _rigidbody;

    private Vector3 _endPosition;
    private bool _isEndState = false;
    #endregion


    #region Data Constructs
    #endregion


    #region MonoBehaviour Loop
    private void Awake()
    {
        _transform = transform;
        _collider = GetComponent<Collider>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (_isEndState)
        {
            _transform.position = Vector3.Lerp(_transform.position, _endPosition, Time.deltaTime * 5f);
        }
    }
    #endregion
    
    
    #region Event Handlers
    #endregion
    

    #region Internal Functions
    internal void SetEndState(Vector3 endPosition)
    {
        _transform.localScale = new Vector3(_endScale, _endScale, _endScale);
        _transform.localEulerAngles = _endRotation;
        _rigidbody.isKinematic = true;
        _rigidbody.useGravity = false;
        _collider.enabled = false;
        _endPosition = endPosition;
        _isEndState = true;
    }
    #endregion


    #region Public API
    #endregion
}
