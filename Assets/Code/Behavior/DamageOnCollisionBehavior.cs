using CoreSystem.IdentitySystem;
using CoreSystem.StateMachine;
using HealthSystem;
using UnityEngine;

namespace Behavior
{
    
    [CreateAssetMenu(menuName = "Create Behavior/DamageOnCollisionBehavior", fileName = "DamageOnCollisionBehavior", order = 0)]
    public class DamageOnCollisionBehavior : BaseBehavior
    {
        [SerializeField] private int damage;
        [SerializeField] private bool destroyOnCollision;
        
        public override void OnTriggerEnter2D(Collider2D other)
        {
            var damageable = other.GetComponent<IDamageable>();
            if (damageable == null) return;
            var owner = other.GetComponent<Owner>();
            damageable.TakeDamage(damage, Controller.transform.position, Controller.transform.up, Controller.GetOwner());
            if (owner && owner == Controller.GetOwner()) return;
            if (!destroyOnCollision) return;
            Destroy(Controller.gameObject);
        }
    }
}