using UnityEngine;
using Weapon;

[RequireComponent(typeof(WeaponHandler), typeof(AudioSource))]
public class FireSoundHandler : MonoBehaviour
{
    private AudioSource _audioSource;
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        GetComponent<WeaponHandler>().OnFireEventWithAudio += _audioSource.PlayOneShot;
    }

}
