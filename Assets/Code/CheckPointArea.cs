using UnityEngine;

public class CheckPointArea : MonoBehaviour
{
    public static Vector2 LastSavedPosition;
    
    [SerializeField ]private Transform spawnPoint;
    private bool _isTriggerd;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!_isTriggerd && other.CompareTag("Player"))
        {
            _isTriggerd = true;
            LastSavedPosition = spawnPoint.position;
        }
    }
}
