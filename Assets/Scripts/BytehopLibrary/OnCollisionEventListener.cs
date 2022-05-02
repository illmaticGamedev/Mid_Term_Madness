using UnityEngine;
using UnityEngine.Events;

namespace BytehopLibrary
{
public class OnCollisionEventListener : MonoBehaviour
{
   public UnityEvent OnColliderEnterHit;
   public UnityEvent OnTriggerEnterHit;
   
   //advance options
   [SerializeField] private Transform lastHitObject;
   private void OnCollisionEnter(Collision other)
   {
      lastHitObject = other.transform;
      OnColliderEnterHit.Invoke();
   }
   private void OnTriggerEnter(Collider other)
   {
      lastHitObject = other.transform;
      OnTriggerEnterHit.Invoke();
   }
}
}