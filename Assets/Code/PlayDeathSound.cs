using HealthSystem;
using UnityEngine;

public class PlayDeathSound : MonoBehaviour
{
    [SerializeField] private AudioClip soundEffect;

    private AudioSource _audioSource;
    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        GetComponent<HealthHandler>().OnDiedEvent += PlayHitSound;
    }

    private void PlayHitSound()
    {
        _audioSource.PlayOneShot(soundEffect);
    }
}
