using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MidTermMadness
{
    public class InputManager : MonoBehaviour
    {
        public static InputManager Instance;
        
       [HideInInspector] public Vector3 MovementDirection;
       [HideInInspector] public Vector3 MovementDirectionRaw;
        public KeyCode RunningButton;

        private void Awake()
        {
            Instance = this;
        }
        
        private void Update()
        {
            CheckMovementInput();
            CheckRawMovementInput();
        }

        private void CheckMovementInput()
        {
            MovementDirection = Vector3.Lerp(MovementDirection, new Vector3(Input.GetAxis("Horizontal"),0,Input.GetAxis("Vertical")), 1);
        }
        
        private void CheckRawMovementInput()
        {
            MovementDirectionRaw =  new Vector3(Input.GetAxisRaw("Horizontal"),0,Input.GetAxisRaw("Vertical"));
        }

        public bool CheckRunningInput()
        {
            if (Input.GetKey(RunningButton))
            {
                return true;
            }
            else return false;
        }
    }
}
