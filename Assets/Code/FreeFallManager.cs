using Code;
using HealthSystem;
using UnityEngine;

[RequireComponent(typeof(HealthHandler))]
public class FreeFallManager : MonoBehaviour
{
    [SerializeField][Range(0.0001f,1f)]
    private float rotationSpeed;
    
    private Rigidbody2D _rigidbody2D;
    private GroundedHandler _groundedHandler;
    private HealthHandler _healthHandler;
    private bool _isDead;
    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _groundedHandler = GetComponent<GroundedHandler>();
        _healthHandler = GetComponent<HealthHandler>();
        _healthHandler.OnDiedEvent += Died;
        PlayerDiedHandler.OnPlayerRespawnEvent += Respawned;

    }

    private void Respawned()
    {
        _isDead = false;
    }

    private void Died()
    {
        _rigidbody2D.constraints = RigidbodyConstraints2D.None;
        _isDead = true;
    }

    private void Update()
    {
        if (_isDead) return;
        _rigidbody2D.constraints = _groundedHandler.IsGrounded() ? RigidbodyConstraints2D.FreezeRotation : RigidbodyConstraints2D.None;
        if (_rigidbody2D.constraints == RigidbodyConstraints2D.FreezeRotation && _groundedHandler.IsGrounded()) GetUp();
    }

    private void GetUp()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0,0,0), rotationSpeed);
    }
}
