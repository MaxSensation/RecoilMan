using System;
using HealthSystem;
using UnityEngine;

public class PlayerDiedHandler : MonoBehaviour
{
    public static Action OnPlayerRespawnEvent;
    
    [SerializeField] private float respawnTime; 
    private HealthHandler _healthHandler;
    private float timeOfDeath;
    private bool died;

    private void Start()
    {
        _healthHandler = GetComponent<HealthHandler>();
        _healthHandler.OnDiedEvent += Died;
    }

    private void Update()
    {
        if (died && Time.time - timeOfDeath >= respawnTime)
        {
            died = false;
            transform.position = CheckPointArea.LastSavedPosition;
            OnPlayerRespawnEvent?.Invoke();
        }
    }

    private void Died()
    {
        timeOfDeath = Time.time;
        died = true;
    }
}
