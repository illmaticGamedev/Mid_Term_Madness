using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MidTermMadness
{
    [RequireComponent(typeof(Animator))]
    public class PlayerAnimator : MonoBehaviour
    {
        private Animator playerAnimator;
        private static readonly int Moving = Animator.StringToHash("IsMoving");
        private static readonly int Running = Animator.StringToHash("IsRunning");

        private void Awake()
        {
            playerAnimator = GetComponent<Animator>();
        }

        private void Start()
        {
            UpdateMovementAnimation(false,false);
        }

        public void UpdateMovementAnimation(bool IsMoving, bool IsRunning)
        {
            playerAnimator.SetBool(Moving,IsMoving);
            playerAnimator.SetBool(Running,IsRunning);
        }
    }
}
