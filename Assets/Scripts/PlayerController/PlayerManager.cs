using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MidTermMadness
{
    public class PlayerManager : MonoBehaviour
    {
        //Managers
        private InputManager pInput;
        
        //Components
        [SerializeField] private PlayerMovement pMovement;
        [SerializeField] private PlayerAnimator pAnimator;

        private void Start()
        {
            pInput = InputManager.Instance;
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
