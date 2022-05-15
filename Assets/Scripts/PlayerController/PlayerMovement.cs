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

        // Movement
         private float walkSpeed;
         private float runSpeed;
         private float moveSpeed;

        // Rotation
         private float rotationSpeed;
         private Quaternion lastTargetRotation = Quaternion.identity;
         private Rigidbody playerRB;

        private void Awake()
        {
            playerRB = GetComponent<Rigidbody>();
            TriggerRunning(isRunning);
        }
        
        public void MoveAndRotatePlayer(Vector3 dirVector)
        {
            Quaternion targetRotation = Quaternion.identity;
            
            if (dirVector != Vector3.zero)
            {
                isMoving = true;
                dirVector.Normalize();
                playerRB.velocity = (dirVector * moveSpeed);
                
            }
            else
            {
                isMoving = false;
            }

            
            if (InputManager.Instance.MovementDirectionRaw != Vector3.zero)
            {
                targetRotation = Quaternion.LookRotation(dirVector, Vector3.up);
                playerRB.rotation = Quaternion.RotateTowards(playerRB.rotation, targetRotation, rotationSpeed);
                lastTargetRotation = targetRotation;
            }
            else
            {
                playerRB.rotation = Quaternion.RotateTowards(playerRB.rotation, lastTargetRotation, rotationSpeed);
                playerRB.velocity = Vector3.zero;
                isMoving = false;
            }

        }

        public void TriggerRunning(bool state)
        {
            isRunning = state;

            if (!state) moveSpeed = walkSpeed;
            else moveSpeed = runSpeed;
        }

        public void SetMovementValues(float walk, float run, float rotation)
        {
            walkSpeed = walk;
            runSpeed = run;
            rotationSpeed = rotation;
        }
    }
}