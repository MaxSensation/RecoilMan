using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private Vector3 cameraOffset;
    [SerializeField][Range(0.001f,1f)] private float smooth;
    
    private Transform _playerTransform;

    private RecoilManInput _recoilManInput;

    private void Awake()
    {
        _recoilManInput = new RecoilManInput();
        _playerTransform = GameObject.FindWithTag("Player").transform;
    }

    private void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, _playerTransform.position + cameraOffset, smooth);
    }
}
