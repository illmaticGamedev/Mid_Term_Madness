using System;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

namespace BytehopLibrary
{
    public class CamFollow : MonoBehaviour
    {
        [SerializeField] private bool autoDetectOffsetFromScene = false;
        [SerializeField] private float followSpeed;
        [SerializeField] private Transform target;
        [SerializeField] private Vector3 followOffset;

        private void Start()
        {
            if (autoDetectOffsetFromScene)
            {
                followOffset = target.position - transform.position;
            }
        }

        private void FixedUpdate()
        {
            transform.position = Vector3.Lerp(transform.position, target.position + followOffset, followSpeed);
        }
    }
}
