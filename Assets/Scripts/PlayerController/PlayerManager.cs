using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MidTermMadness
{
    public class PlayerManager : MonoBehaviour
    {
        [Header(" PLAYER SETTINGS ")] 
        [SerializeField] float walkSpeed;
        [SerializeField] float runSpeed;
        [SerializeField] float rotationSpeed;
        
        //Managers
        private InputManager pInput;
        
        //Components
        private PlayerMovement pMovement;
        private PlayerAnimator pAnimator;

        private void Start()
        {
            pInput = InputManager.Instance;
            pMovement = GetComponentInChildren<PlayerMovement>();
            pAnimator = GetComponentInChildren<PlayerAnimator>();
            pMovement.SetMovementValues(walkSpeed,runSpeed,rotationSpeed);
        }

        private void FixedUpdate()
        {
            //Check if player wants to run
            if (pInput.CheckRunningInput())
            {
                pMovement.TriggerRunning(true);
            }
            else
            {
                pMovement.TriggerRunning(false);
            }
            
            //move and animate
            pMovement.MoveAndRotatePlayer(pInput.MovementDirection);
            pAnimator.UpdateMovementAnimation(pMovement.isMoving, pMovement.isRunning);
        }
    }
}
