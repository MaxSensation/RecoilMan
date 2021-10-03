using CoreSystem.StateMachine;
using UnityEngine;

namespace Behavior
{
    [CreateAssetMenu(menuName = "Create Behavior/LifeTimeBehavior", fileName = "LifeTimeBehavior", order = 0)]
    public class LifeTimeBehavior : BaseBehavior
    {
        [SerializeField] private float lifeTime;

        public override void EnterBehavior(SMController controller)
        {
            base.EnterBehavior(controller);
            Destroy(Controller.gameObject, lifeTime);
        }
    }
}