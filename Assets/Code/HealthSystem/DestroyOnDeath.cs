using UnityEngine;

namespace HealthSystem
{
    [RequireComponent(typeof(HealthHandler))]
    public class DestroyOnDeath : MonoBehaviour
    {
        private void Start() => GetComponent<HealthHandler>().OnDiedEvent += Die;

        private void Die() => Destroy(gameObject);
    }
}