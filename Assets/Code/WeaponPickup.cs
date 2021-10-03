using System;
using UnityEngine;

namespace Code
{
    [Serializable]
    internal enum WeaponType
    {
        Pistol,
        Uzi,
        Sniper
    }
    
    [RequireComponent(typeof(BoxCollider2D), typeof(AudioSource))]
    public class WeaponPickup : MonoBehaviour
    {
        public static Action<int> OnPickedUpWeapon;
        [SerializeField] private WeaponType weaponType;
        [SerializeField]private AudioClip soundEffect;
        
        private bool _hasBeenTriggerd;
        private AudioSource _audioSource;

        private void Start()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (_hasBeenTriggerd || !other.CompareTag("Player")) return;
            _hasBeenTriggerd = true;
            switch (weaponType)
            {
                case WeaponType.Pistol:
                    OnPickedUpWeapon?.Invoke(0);
                    break;
                case WeaponType.Uzi:
                    OnPickedUpWeapon?.Invoke(1);
                    break;
                case WeaponType.Sniper:
                    OnPickedUpWeapon?.Invoke(2);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            _audioSource.PlayOneShot(soundEffect);
            GetComponentInChildren<SpriteRenderer>().enabled = false;
            Destroy(gameObject, soundEffect.length);
        }
    }
}