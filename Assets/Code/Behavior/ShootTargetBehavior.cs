using CoreSystem.DataSystem;
using CoreSystem.StateMachine;
using UnityEngine;
using Weapon;

namespace Behavior
{
    [CreateAssetMenu(menuName = "Create Behavior/ShootTargetBehavior", fileName = "ShootTargetBehavior", order = 0)]
    public class ShootTargetBehavior : BaseBehavior
    {
        [SerializeField] private Vector3 offset;
        [SerializeField] private GameObjectDataType target;
        private WeaponHandler _weaponHandler;
        
        public override void EnterBehavior(SMController controller)
        {
            base.EnterBehavior(controller);
            _weaponHandler = Controller.GetComponent<WeaponHandler>();
        }

        public override void UpdateBehavior()
        {
            base.UpdateBehavior();
            if (_weaponHandler && IsPlayerInSight()) Fire();
        }

        private bool IsPlayerInSight()
        {
            var hit = Physics2D.Linecast(Controller.transform.position + offset, target.Data.transform.position);
            return hit.collider.gameObject == target.Data.gameObject;
        }

        private void Fire() => _weaponHandler.Fire();
    }
}