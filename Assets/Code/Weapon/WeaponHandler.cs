using System;
using CoreSystem.IdentitySystem;
using UnityEngine;

namespace Weapon
{
    public class WeaponHandler : MonoBehaviour, IProperty
    {
        public Action OnFireEvent;
        public Action<AudioClip> OnFireEventWithAudio;
        
        [SerializeField] private WeaponBase weaponBase;
        [SerializeField] private Transform projectileSpawnPoint;

        private bool _hasBeenSetup;
        private Owner _owner;
        private bool _isUnlocked;

        private void Start()
        {
            weaponBase = Instantiate(weaponBase);
            weaponBase.OnFiredEvent += OnFire;
        }

        private void OnFire()
        {
            OnFireEvent?.Invoke();
            OnFireEventWithAudio?.Invoke(weaponBase.GetSoundClip());
        }

        public void Fire()
        {
            if (!_hasBeenSetup) SetupWeapon(); else weaponBase.Fire();
        }

        public void SetupWeapon()
        {
            weaponBase.SetWeaponParams(projectileSpawnPoint);
            weaponBase.SetOwner(_owner);
            _hasBeenSetup = true;
        }

        public void SetOwner(Owner owner)
        {
            _owner = owner;
        }

        public Owner GetOwner()
        {
            return _owner;
        }

        public void Unlock()
        {
            _isUnlocked = true;
        }

        public bool IsUnlocked()
        {
            return _isUnlocked;
        }
    }
}