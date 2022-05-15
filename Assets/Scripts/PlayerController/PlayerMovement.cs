using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

namespace MidTermMadness
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private Vector3 dirVector;
        [SerializeField] private bool isRunning = false;
        
        [Header("Movement")]
        [SerializeField] private float walkSpeed;
        [SerializeField] private float runSpeed;
        private float moveSpeed;

        [Header("Rotation")] 
        [SerializeField] private float rotationSpeed;
        
        private Rigidbody playerRB;

        private void Awake()
        {
            playerRB = GetComponentInChildren<Rigidbody>();
            moveSpeed = walkSpeed;
        }

        private void Update()
        {
            dirVector.x = Input.GetAxisRaw("Horizontal");
            dirVector.z = Input.GetAxisRaw("Vertical");
        }

        private void FixedUpdate()
        {
            MovePlayer();
        }

        void MovePlayer()
        {
            playerRB.velocity = (dirVector * moveSpeed);
            // playerRB.rotation =
           //     Quaternion.RotateTowards(rotation, Quaternion.Euler(dirVector - new Vector3(rotation.x,rotation.y,rotation.z)), rotationSpeed);
        }

        public void TriggerRunning(bool state)
        {
            isRunning = state;

            if (state) moveSpeed = walkSpeed;
            else moveSpeed = runSpeed;
        }
        
    }
}
