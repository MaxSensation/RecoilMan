using CoreSystem.IdentitySystem;
using UnityEngine;

namespace CoreSystem.StateMachine 
{
    public class SMController : MonoBehaviour, IProperty
    {
        [SerializeField]
        private BaseState startBaseState;
        
        private BaseState _currentBaseState;
        private Owner _owner;
        private void Start()
        {
            if (startBaseState)
                ChangeState(startBaseState);
            else
                throw new MissingReferenceException("No startingState assigned!");
        }

        private void Update() => _currentBaseState.UpdateState();

        public void ChangeState(BaseState newBaseState)
        {
            if (_currentBaseState) _currentBaseState.ExitState();
            _currentBaseState = Instantiate(newBaseState);
            _currentBaseState.EnterState(this);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            _currentBaseState.OnTriggerEnter2D(other);
        }

        public void SetOwner(Owner owner) => _owner = owner;
        public Owner GetOwner() => _owner;
    }
}