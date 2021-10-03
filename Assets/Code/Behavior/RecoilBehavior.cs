using CoreSystem.StateMachine;
using UnityEngine;

namespace Behavior
{
    [CreateAssetMenu(menuName = "Create Behavior/RecoilBehavior", fileName = "RecoilBehavior", order = 0)]
    public class RecoilBehavior : BaseBehavior
    {
        [SerializeField] private float recoilForce;
        
        public override void EnterBehavior(SMController controller)
        {
            var recoil = controller.GetOwner().gameObject.GetComponentInChildren<RecoilManagement>();
            if (recoil) recoil.AddRecoil(recoilForce);
        }
    }
}