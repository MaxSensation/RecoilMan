using UnityEngine;

namespace Code
{
    public class GroundedHandler : MonoBehaviour
    {
        [SerializeField] private LayerMask whatIsGround;
        [SerializeField] private Transform groundCheck;

        private const float GroundedRadius = .2f;
        private bool _grounded;

        private void FixedUpdate()
        {
            _grounded = false;
            var colliders = Physics2D.OverlapCircleAll(groundCheck.position, GroundedRadius, whatIsGround);
            foreach (var collider in colliders)
            {
                if (collider.gameObject == gameObject) continue;
                _grounded = true;
            }
        }

        public bool IsGrounded() => _grounded;
    }
}