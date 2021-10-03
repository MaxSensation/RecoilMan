using CoreSystem.StateMachine;
using UnityEngine;

namespace Behavior
{
    [CreateAssetMenu(menuName = "Create Behavior/AddPushBackOnCollisionBehavior", fileName = "AddPushBackOnCollisionBehavior", order = 0)]
    public class AddPushBackOnCollisionBehavior : BaseBehavior
    {
        [SerializeField] private float force;
        
        public override void OnTriggerEnter2D(Collider2D other)
        {
            var pushBackWhenShoot = other.GetComponent<PushBackWhenShoot>();
            if (pushBackWhenShoot == null) return;
            pushBackWhenShoot.AddPushBack(Controller.transform.up * force, Controller.transform.position);
        }
    }
}