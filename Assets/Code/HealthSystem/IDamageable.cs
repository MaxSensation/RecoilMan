using CoreSystem.IdentitySystem;
using UnityEngine;

namespace HealthSystem
{
    public interface IDamageable
    {
        void TakeDamage(int damage, Vector2 position, Vector2 direction, Owner owner);
    }
}