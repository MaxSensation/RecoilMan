using UnityEngine;

public class CameraShakeHandler : MonoBehaviour
{
    [SerializeField] private float minXShake;
    [SerializeField] private float minYShake;
    [SerializeField] private float maxXShake;
    [SerializeField] private float maxYShake;

    private Camera camera;

    private void Start()
    {
        camera = Camera.main;
    }
}
