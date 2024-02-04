using System;
using UnityEngine;

namespace PolySpatial.Samples
{
    [RequireComponent(typeof(Rigidbody))]
    public class PieceSelectionBehavior : MonoBehaviour
    {
        #region Inspector Fields
        [SerializeField] MeshRenderer m_MeshRenderer;
        [SerializeField] Material m_DefaultMat;
        [SerializeField] Material m_SelectedMat;
        [Space]
        [SerializeField] private Transform _root;
        #endregion


        #region Public Properties
        public int SelectingPointer { get; private set; } = ManipulationInputManager.k_Deselected;
        #endregion


        #region Internal Variables
        private Transform _transform;
        private Rigidbody _rigidBody;
        #endregion


        #region Monobehaviour Loop
        private void Awake()
        {
            _transform = transform;
            _rigidBody = GetComponent<Rigidbody>();
            if (_root == null) _root = _transform;
        }
        #endregion


        #region Public API
        public void SetSelected(int pointer)
        {
            bool isSelected = pointer != ManipulationInputManager.k_Deselected;
            SelectingPointer = pointer;
            m_MeshRenderer.material = isSelected ? m_SelectedMat : m_DefaultMat;
            _rigidBody.isKinematic = isSelected;
        }
        public void SetPosRot(Vector3 position, Quaternion rotation)
        {
            _root.SetPositionAndRotation(position, rotation);
        }
        #endregion
    }
}
