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
        public KeyCode RunningButton;

        private void Awake()
        {
            Instance = this;
        }
        
        private void Update()
        {
            CheckMovementInput();
        }

        private void CheckMovementInput()
        {
            MovementDirection.x = Input.GetAxisRaw("Horizontal");
            MovementDirection.z = Input.GetAxisRaw("Vertical");
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
