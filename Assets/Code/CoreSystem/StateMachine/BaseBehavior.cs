using UnityEngine;

namespace CoreSystem.StateMachine
{
    public abstract class BaseBehavior : ScriptableObject
    {
        protected SMController Controller;
        
        public virtual void EnterBehavior(SMController controller) => Controller = controller;
        
        public virtual void UpdateBehavior() {}
        
        public virtual void ExitBehavior() {}

        public virtual void OnTriggerEnter2D(Collider2D other) {}
    }
}