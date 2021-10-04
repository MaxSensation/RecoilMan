using Player;
using UnityEngine;

public class CameraShakeHandler : MonoBehaviour
{
    [SerializeField] private Vector3 amount = new Vector3(1f, 1f, 0);
    [SerializeField] private float duration = 1;
    [SerializeField] private float speed = 10;
    [SerializeField] private AnimationCurve curve = AnimationCurve.EaseInOut(0, 1, 1, 0);

    private Camera _camera;
    private float _time;
    private Vector3 _lastPos;
    private Vector3 _nextPos;
    private float _lastFoV;
    private float _nextFoV;

    private void Start()
    {
        _camera = GetComponent<Camera>();
        PlayerWeaponHandler.OnWeaponDischargedEvent += Shake;
    }

    private void Shake()
    {
        ResetCam();
        _time = duration;
    }
    private void LateUpdate()
    {
        if (!(_time > 0)) return;
        _time -= Time.deltaTime;
        if (_time > 0)
        {
            _nextPos = (Mathf.PerlinNoise(_time * speed, _time * speed * 2) - 0.5f) * amount.x * transform.right * curve.Evaluate(1f - _time / duration) +
                      (Mathf.PerlinNoise(_time * speed * 2, _time * speed) - 0.5f) * amount.y * transform.up * curve.Evaluate(1f - _time / duration);
            _nextFoV = (Mathf.PerlinNoise(_time * speed * 2, _time * speed * 2) - 0.5f) * amount.z * curve.Evaluate(1f - _time / duration);

            _camera.fieldOfView += (_nextFoV - _lastFoV);
            _camera.transform.Translate(_nextPos - _lastPos);

            _lastPos = _nextPos;
            _lastFoV = _nextFoV;
        }
        else
            ResetCam();
    }

    private void ResetCam()
    {
        _camera.transform.Translate(-_lastPos);
        _camera.fieldOfView -= _lastFoV;
        _lastPos = _nextPos = Vector3.zero;
        _lastFoV = _nextFoV = 0f;
    }
}