using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private Vector3 cameraOffset;
    
    private Transform _playerTransform;

    private void Awake()
    {
        _playerTransform = GameObject.FindWithTag("Player").transform;
    }

    private void Update()
    {
        transform.position = (Vector3)_playerTransform.position + cameraOffset;
    }
}
