using HealthSystem;
using TMPro;
using UnityEngine;

namespace UI
{
    public class HealthSystemUI : MonoBehaviour
    {
        [SerializeField] private TMP_Text healthText;

        private void Start()
        {
            var playerGO = GameObject.FindWithTag("Player");
            if (!playerGO)
                throw new MissingReferenceException("No object with the Player tag in the scene, no healthUI will be updated!");
            var healthHandler = playerGO.GetComponent<HealthHandler>();
            if (!healthHandler)
                throw new MissingComponentException("The player is missing the healthHandler component, no healthUI will be updated!");
            healthHandler.OnTakenDamageEvent += UpdateUIText;
            PlayerDiedHandler.OnPlayerRespawnEvent += () => UpdateUIText(healthHandler.GetMaxHP(), Vector2.zero, Vector2.zero);
            UpdateUIText(healthHandler.GetMaxHP(), Vector2.zero, Vector2.zero);
        }

        private void UpdateUIText(int currentHealth, Vector2 pos, Vector2 dir)
        {
            if (currentHealth <= 0)
            {
                currentHealth = 0;
            }
            healthText.SetText($"{currentHealth.ToString()} hp");
        }
    }
}