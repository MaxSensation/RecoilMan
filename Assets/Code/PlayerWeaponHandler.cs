using System;
using HealthSystem;
using UnityEngine;
using Weapon;

namespace Player
{
    [RequireComponent(typeof(WeaponInventory))]
    public class PlayerWeaponHandler : MonoBehaviour
    {
        public static Action OnWeaponDischargedEvent;
        [SerializeField] private HealthHandler healthHandler;
        private RecoilManInput _recoilManInput;
        private bool _holdingFire;
        private WeaponInventory _weaponInventory;
        private bool _isDead;
        
        private void Start()
        {
            healthHandler.OnDiedEvent += Died;
            PlayerDiedHandler.OnPlayerRespawnEvent += Respawned;
            _recoilManInput = new RecoilManInput();
            _recoilManInput.Player.Fire.Enable();
            _recoilManInput.Player.WeaponSlot1.Enable();
            _recoilManInput.Player.WeaponSlot2.Enable();
            _recoilManInput.Player.WeaponSlot3.Enable();
            _recoilManInput.Player.Fire.performed += _ => Fire();
            _recoilManInput.Player.Fire.canceled += _ => _holdingFire = false;
            _weaponInventory = GetComponent<WeaponInventory>();
            _weaponInventory.OnWeaponDischargedEvent += () => OnWeaponDischargedEvent?.Invoke();
            _recoilManInput.Player.WeaponSlot1.performed += _ => _weaponInventory.ChangeWeapon(0);
            _recoilManInput.Player.WeaponSlot2.performed += _ => _weaponInventory.ChangeWeapon(1);
            _recoilManInput.Player.WeaponSlot3.performed += _ => _weaponInventory.ChangeWeapon(2);
        }

        private void Respawned()
        {
            _isDead = false;
        }

        private void Died()
        {
            _isDead = true;
        }

        private void Update()
        {
            if (_holdingFire) Fire();
        }

        private void Fire()
        {
            _holdingFire = true;
            if (!_isDead && Time.timeScale != 0f) _weaponInventory.Fire();
        }
    }
}