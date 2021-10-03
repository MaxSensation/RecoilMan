using HealthSystem;
using UnityEngine;

public class DieAnimationHandler : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private void Start()
    {
        GetComponent<HealthHandler>().OnDiedEvent += Die;
        PlayerDiedHandler.OnPlayerRespawnEvent += Respawned;
    }

    private void Respawned()
    {
        animator.ResetTrigger("Dead");
        animator.SetTrigger("Reset");
    }

    private void Die()
    {
        animator.ResetTrigger("Reset");
        animator.SetTrigger("Dead");
    }
}
