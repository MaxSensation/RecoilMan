using CoreSystem.IdentitySystem;
using HealthSystem;
using UnityEngine;

[RequireComponent(typeof(Owner))]
public class KillZone : MonoBehaviour, IProperty
{
    private Owner _owner;
    private void OnTriggerEnter2D(Collider2D other)
    {
        var damageable = other.GetComponent<IDamageable>();
        if (damageable != null) damageable.TakeDamage(int.MaxValue, other.transform.position, Vector2.zero, _owner);
    }

    public void SetOwner(Owner owner)
    {
        _owner = owner;
    }

    public Owner GetOwner()
    {
        return _owner;
    }
}
