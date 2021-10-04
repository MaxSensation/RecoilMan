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
        [SerializeField] private float range;
        
        private WeaponHandler _weaponHandler;
        
        public override void EnterBehavior(SMController controller)
        {
            base.EnterBehavior(controller);
            _weaponHandler = Controller.GetComponent<WeaponHandler>();
        }

        public override void UpdateBehavior()
        {
            base.UpdateBehavior();
            if (_weaponHandler && IsPlayerInSight() && IsInRange()) Fire();
        }

        private bool IsInRange()
        {
            return Vector2.Distance(Controller.transform.position, target.Data.transform.position) <= range;
        }

        private bool IsPlayerInSight()
        {
            var hit = Physics2D.Linecast(Controller.transform.position + offset, target.Data.transform.position);
            return hit.collider.gameObject == target.Data.gameObject;
        }

        private void Fire() => _weaponHandler.Fire();
    }
}