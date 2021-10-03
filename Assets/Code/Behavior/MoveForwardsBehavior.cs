using CoreSystem.DataSystem;
using CoreSystem.StateMachine;
using UnityEngine;

namespace Behavior
{

    [CreateAssetMenu(menuName = "Create Behavior/MoveForwardsBehavior", fileName = "MoveForwardsBehavior", order = 0)]
    public class MoveForwardsBehavior : BaseBehavior
    { 
        [SerializeField] private float movementSpeed;

        public override void UpdateBehavior()
        {
            base.UpdateBehavior();
            Move();
        }

        private void Move() => Controller.transform.position += Controller.transform.up * (movementSpeed * Time.deltaTime);
    }
}