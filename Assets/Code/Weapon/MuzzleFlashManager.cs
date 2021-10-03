using UnityEngine;
using Weapon;
using Random = UnityEngine.Random;

[RequireComponent(typeof(SpriteRenderer))]
public class MuzzleFlashManager : MonoBehaviour
{
    [SerializeField] private float minTime = 0.01f;
    [SerializeField] private float maxTime = 0.05f;
    [SerializeField] private float minSize = 1f;
    [SerializeField] private float maxSize = 1.2f;
    [SerializeField] private Sprite[] muzzleFlashVariations;
    [SerializeField] private WeaponHandler weaponHandler;
    
    private SpriteRenderer _renderer;
    private float _timeAtActivate;
    private float _currentTimer;
    private void Start()
    {
        weaponHandler.OnFireEvent += OnFire;
        _renderer = GetComponent<SpriteRenderer>();
    }

    private void OnFire()
    {
        transform.localScale = Vector3.one * Random.Range(minSize, maxSize);
        _renderer.flipY = Random.Range(0, 2) > 0;
        _renderer.sprite = muzzleFlashVariations[Random.Range(0,muzzleFlashVariations.Length)];
        _currentTimer = Random.Range(minTime, maxTime);
        _renderer.enabled = true;
        _timeAtActivate = Time.time;
    }

    private void Update()
    {
        if (Time.time - _timeAtActivate >= _currentTimer) _renderer.enabled = false;
    }
}
