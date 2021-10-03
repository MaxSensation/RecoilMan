using HealthSystem;
using UnityEngine;

[RequireComponent(typeof(HealthHandler))]
public class BloodGenerator : MonoBehaviour
{
    [SerializeField] private Transform bloodGeneratorTransform;
    [SerializeField] private ParticleSystem particleSystem;

    private HealthHandler _healthHandler;
    private void Start()
    {
        _healthHandler = GetComponent<HealthHandler>();
        _healthHandler.OnTakenDamageEvent += TakeDamage;
    }

    private void TakeDamage(int damage, Vector2 position, Vector2 direction)
    {
        bloodGeneratorTransform.position = position;
        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        bloodGeneratorTransform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        particleSystem.Play();
    }
}
