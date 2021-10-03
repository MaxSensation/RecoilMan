using UnityEngine;

namespace HealthSystem
{
    [RequireComponent(typeof(HealthHandler))]
    public class HealthColorChanger : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer spriteRenderer;
        [SerializeField] private Color fullHealthColor;
        [SerializeField] private Color lowHealthColor;
    
        private HealthHandler _healthHandler;

        private void Start()
        {
            _healthHandler = GetComponent<HealthHandler>();
            _healthHandler.OnTakenDamageEvent += UpdateColor;
            spriteRenderer.color = fullHealthColor;
        }

        private void UpdateColor(int newHealth, Vector2 pos, Vector2 dir)
        {
            spriteRenderer.color = Color.Lerp(lowHealthColor, fullHealthColor, (float)newHealth / _healthHandler.GetMaxHP());
        }
    }
}
