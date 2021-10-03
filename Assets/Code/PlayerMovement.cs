using Code;
using HealthSystem;
using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
	[SerializeField] private float jumpForce = 400f;
	[Range(0, .3f)] [SerializeField] private float movementSmoothing = .05f;
	[SerializeField] private bool airControl;

	private GroundedHandler _groundedHandler;
	private Rigidbody2D _body;
	private bool _facingRight = true;
	private Vector3 _velocity = Vector3.zero;

	private RecoilManInput _recoilManInput;
	private Vector2 _moveInput;
	private bool _jumpQued;
	private HealthHandler _healthHandler;
	private bool _isDead;
	private void Awake()
	{
		_healthHandler = GetComponent<HealthHandler>();
		_groundedHandler = GetComponent<GroundedHandler>();
		_body = GetComponent<Rigidbody2D>();
		_recoilManInput = new RecoilManInput();
		_recoilManInput.Player.Move.Enable();
		_recoilManInput.Player.Jump.Enable();
		_recoilManInput.Player.Move.performed += c => _moveInput = c.ReadValue<Vector2>();
		_recoilManInput.Player.Move.canceled += c => _moveInput = c.ReadValue<Vector2>();
		_recoilManInput.Player.Jump.performed += c => _jumpQued = true;
		_healthHandler.OnDiedEvent += Died;
		PlayerDiedHandler.OnPlayerRespawnEvent += Respawned;
	}

	private void Respawned()
	{
		_isDead = false;
		_body.velocity = Vector2.zero;
	}

	private void Died()
	{
		_isDead = true;
	}

	private void FixedUpdate()
	{
		if (!_isDead) Move(_moveInput.x, _jumpQued);
	}


	private void Move(float move, bool jump)
	{
		if (_groundedHandler.IsGrounded() || airControl)
		{
			Vector3 targetVelocity = new Vector2(move * 10f, _body.velocity.y);
			_body.velocity = Vector3.SmoothDamp(_body.velocity, targetVelocity, ref _velocity, movementSmoothing);
			if (move > 0 && !_facingRight)
				Flip();
			else if (move < 0 && _facingRight) Flip();
		}
		if (!_groundedHandler.IsGrounded() || !jump) return;
		_body.AddForce(new Vector2(0f, jumpForce));
		_jumpQued = false;
	}


	private void Flip()
	{
		_facingRight = !_facingRight;
		var theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}