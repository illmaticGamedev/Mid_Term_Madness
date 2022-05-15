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
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerMovement : MonoBehaviour
    {
       
        [HideInInspector] public bool isRunning = false;
        [HideInInspector] public bool isMoving = false;

        [Header("Movement")] 
        [SerializeField] private float walkSpeed;
        [SerializeField] private float runSpeed;
        private float moveSpeed;

        [Header("Rotation")] [SerializeField] private float rotationSpeed;

        private Rigidbody playerRB;

        private void Awake()
        {
            playerRB = GetComponent<Rigidbody>();
            TriggerRunning(isRunning);
        }
        
        public void MoveAndRotatePlayer(Vector3 dirVector)
        {
            if (dirVector != Vector3.zero)
            {
                isMoving = true;
                dirVector.Normalize();
                playerRB.velocity = (dirVector * moveSpeed);

                Quaternion targetRotation = Quaternion.LookRotation(dirVector, Vector3.up);
                playerRB.rotation = Quaternion.RotateTowards(playerRB.rotation, targetRotation, rotationSpeed);
            }
            else
            {
                isMoving = false;
                playerRB.velocity = Vector3.zero;
            }
        }

        public void TriggerRunning(bool state)
        {
            isRunning = state;

            if (!state) moveSpeed = walkSpeed;
            else moveSpeed = runSpeed;
        }
    }
}