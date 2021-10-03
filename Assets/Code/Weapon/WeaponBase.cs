using System;
using CoreSystem.IdentitySystem;
using CoreSystem.StateMachine;
using UnityEngine;

namespace Weapon
{
    [CreateAssetMenu(menuName = "Create Weapon/WeaponBase", fileName = "WeaponBase", order = 0)]
    public class WeaponBase : ScriptableObject, IProperty
    {
        public Action OnFiredEvent;
        
        [SerializeField] private float fireRate;
        [SerializeField] private GameObject projectilePrefab;
        [SerializeField] private AudioClip firedSound;
        
        private Transform _spawnPoint;
        private float _lastTimeFired;
        private Owner _owner;

        public virtual void Fire()
        {
            if (Time.time - _lastTimeFired < fireRate && _lastTimeFired != 0f) return;
            var projectile = Instantiate(projectilePrefab, _spawnPoint.position, _spawnPoint.rotation);
            projectile.GetComponent<SMController>().SetOwner(_owner);
            _lastTimeFired = Time.time;
            OnFiredEvent?.Invoke();
        }

        public void SetWeaponParams(Transform spawnPoint) => _spawnPoint = spawnPoint;
        public void SetOwner(Owner owner) => _owner = owner;
        public Owner GetOwner() => _owner;

        public AudioClip GetSoundClip()
        {
            return firedSound;
        }
    }
}