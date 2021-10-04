using HealthSystem;
using UnityEngine;
using UnityEngine.InputSystem;

public class RotateTowardsMouse : MonoBehaviour
{
    [SerializeField] private HealthHandler healthHandler;
    private RecoilManInput _input;
    private Vector2 _aimPosition;
    private bool isDead;
    private void Start()
    {
        _input = new RecoilManInput();
        _input.Player.AimPosition.Enable();
        _input.Player.AimPosition.performed += UpdateAimPosition;
        _input.Player.AimPosition.canceled += UpdateAimPosition;
        healthHandler.OnDiedEvent += Died;
        PlayerDiedHandler.OnPlayerRespawnEvent += Respawned;
    }

    private void Respawned()
    {
        isDead = false;
    }

    private void Died()
    {
        isDead = true;
    }

    private void Update()
    {
        if (!isDead && Time.timeScale != 0f) Rotate();
    }

    private void Rotate() => transform.rotation = GetRotationTowardsPosition(Camera.main.ScreenToWorldPoint(_aimPosition), transform.position);

    private void UpdateAimPosition(InputAction.CallbackContext context) => _aimPosition = context.ReadValue<Vector2>();

    private Quaternion GetRotationTowardsPosition(Vector3 startPosition, Vector3 endPosition)
    {
        var direction = endPosition - startPosition;
        return Quaternion.AngleAxis(Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f, Vector3.forward);
    }
}