using Code;
using UnityEngine;

public class WalkingAnimationHandler : MonoBehaviour
{
    [SerializeField] private Rigidbody2D body;
    [SerializeField] private GroundedHandler groundedHandler;
    [SerializeField] private double walkingTollerance;
    private Animator _animator;
    private static readonly int Walking = Animator.StringToHash("Walking");

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        RunAnimation();
    }

    private void RunAnimation()
    {
        if (groundedHandler.IsGrounded())
            _animator.SetBool(Walking, body.velocity.magnitude > walkingTollerance);
        else
            _animator.SetBool(Walking, false);
    }
}
