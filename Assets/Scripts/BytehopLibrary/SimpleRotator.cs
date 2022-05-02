using UnityEngine;

namespace BytehopLibrary
{
    public class SimpleRotator : MonoBehaviour
    {
        [Header("Speed")]
        [SerializeField] private float RotateSpeed;
        
        [Header("Angles")]
        [SerializeField] private Vector3 rotationVector;
        
        [Header("Multiply By DeltaTime ?")]
        [SerializeField] private bool DeltaTime = true;
        
        private void Update()
        {
            if(DeltaTime)
                transform.Rotate(rotationVector * (Time.deltaTime * RotateSpeed));
            else
            {
                transform.Rotate(rotationVector  * RotateSpeed);
            }
        }

    }
}