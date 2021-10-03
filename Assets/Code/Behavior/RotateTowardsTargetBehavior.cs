using CoreSystem;
using CoreSystem.DataSystem;
using CoreSystem.StateMachine;
using UnityEngine;

namespace Behavior
{
    
    [CreateAssetMenu(menuName = "Create Behavior/RotateTowardsTargetBehavior", fileName = "RotateTowardsTargetBehavior", order = 0)]
    public class RotateTowardsTargetBehavior : BaseBehavior
    {
        [SerializeField]
        private GameObjectDataType target;
        [SerializeField] private Vector3 offset;
        [SerializeField][Range(0,1)] 
        private float rotationSpeed = 1f;
        
        public override void UpdateBehavior()
        {
            base.UpdateBehavior();
            if(target.Data) Rotate();
        }

        private void Rotate() => Controller.transform.rotation = Quaternion.Lerp(Controller.transform.rotation, HelpClass.GetRotationTowardsPosition(Controller.transform.position, target.Data.transform.position + offset), rotationSpeed);
    }
}