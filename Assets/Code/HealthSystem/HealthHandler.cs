using System;
using CoreSystem.IdentitySystem;
using UnityEngine;

namespace HealthSystem
{
    public class HealthHandler : MonoBehaviour, IDamageable, IProperty
    {
        public Action<int, Vector2, Vector2> OnTakenDamageEvent;
        public Action OnDiedEvent;

        [SerializeField] private int maxHealth;
        
        private Owner _owner;
        private int _currentHealth;

        private void Awake()
        {
            _currentHealth = maxHealth;
            PlayerDiedHandler.OnPlayerRespawnEvent += Respawned;
        }

        private void Respawned()
        {
            _currentHealth = maxHealth;
        }

        public void TakeDamage(int damage, Vector2 position, Vector2 direction, Owner owner)
        {
            if (owner == _owner) return;
            TakeDamage(damage, position, direction);
        }

        public int GetMaxHP() => maxHealth;

        public void SetOwner(Owner owner) => _owner = owner;
        public Owner GetOwner() => _owner;

        public void TakeDamage(int damage, Vector2 position, Vector2 direction)
        {
            var lastHealth = _currentHealth;
            _currentHealth -= damage;
            OnTakenDamageEvent?.Invoke(_currentHealth, position, direction);
            if (_currentHealth > 0 || lastHealth <= 0) return;
            OnDiedEvent?.Invoke();
        }
    }
}