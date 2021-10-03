using CoreSystem.StateMachine;
using UnityEngine;

namespace Behavior
{
    [CreateAssetMenu(menuName = "Create Behavior/MoveForwardInSinusWaveBehavior", fileName = "MoveForwardInSinusWaveBehavior", order = 0)]
    public class MoveForwardInSinusWaveBehavior : BaseBehavior
    {
        [SerializeField]
        private float moveSpeed = 10.0f;
        [SerializeField]
        private float frequency = 10.0f;
        [SerializeField]
        private float magnitude = 0.8f;

        private Vector3 _pos;

        public override void EnterBehavior(SMController controller)
        {
            base.EnterBehavior(controller);
            _pos = Controller.transform.position;
        }

        public override void UpdateBehavior()
        {
            base.UpdateBehavior();
            _pos += Controller.transform.up * Time.deltaTime * moveSpeed;
            Controller.transform.position = _pos + Controller.transform.right * Mathf.Sin(Time.time * frequency) * magnitude;
        }
    }
}