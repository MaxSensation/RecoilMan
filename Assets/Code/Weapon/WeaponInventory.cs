using System;
using System.Collections.Generic;
using Code;
using CoreSystem.IdentitySystem;
using UnityEngine;

namespace Weapon
{
    public class WeaponInventory : MonoBehaviour, IProperty
    {
        public Action OnWeaponDischargedEvent;
        private List<WeaponHandler> _weapons;
        private WeaponHandler _currentWeapon;
        private Owner _owner;

        private void Start()
        {
            _weapons = new List<WeaponHandler>(GetComponentsInChildren<WeaponHandler>());
            foreach (var weapon in _weapons)
            {
                weapon.SetOwner(_owner);
                weapon.SetupWeapon();
                weapon.gameObject.SetActive(false);
                weapon.OnFireEvent += () => OnWeaponDischargedEvent?.Invoke();
            }
            WeaponPickup.OnPickedUpWeapon += PickupWeapon;
        }

        private void PickupWeapon(int weapon)
        {
            if (_currentWeapon) _currentWeapon.gameObject.SetActive(false);
            _currentWeapon = _weapons[weapon];
            _currentWeapon.gameObject.SetActive(true);
            _currentWeapon.Unlock();
        }

        public void Fire()
        {
            if (_currentWeapon) _currentWeapon.Fire();
        }

        public void ChangeWeapon(int slot)
        {
            if (slot < 0 || slot >= _weapons.Count || _weapons[slot] == _currentWeapon || !_weapons[slot].IsUnlocked()) return;
            _currentWeapon.gameObject.SetActive(false);
            _currentWeapon = _weapons[slot];
            _currentWeapon.gameObject.SetActive(true);
        }

        public void SetOwner(Owner owner) => _owner = owner;
        public Owner GetOwner() => _owner;
    }
}