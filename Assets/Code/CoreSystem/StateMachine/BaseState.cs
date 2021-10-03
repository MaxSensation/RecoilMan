using UnityEngine;

namespace CoreSystem.StateMachine
{
    [CreateAssetMenu(menuName = "Create State", fileName = "State", order = 0)]
    public class BaseState : ScriptableObject
    {
        [SerializeField] private BaseBehavior[] behaviors;

        private void CreateCopyOfBehaviors()
        {
            for (var i = 0; i < behaviors.Length; i++) behaviors[i] = Instantiate(behaviors[i]);
        }
        
        public virtual void EnterState(SMController controller)
        {
            CreateCopyOfBehaviors();
            foreach (var behavior in behaviors) behavior.EnterBehavior(controller);
        }

        public virtual void UpdateState()
        {
            foreach (var behavior in behaviors) behavior.UpdateBehavior();
        }

        public virtual void ExitState()
        {
            foreach (var behavior in behaviors) behavior.ExitBehavior();
        }

        public void OnTriggerEnter2D(Collider2D other)
        {
            foreach (var behavior in behaviors) behavior.OnTriggerEnter2D(other);
        }
    }
}