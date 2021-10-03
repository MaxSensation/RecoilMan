using HealthSystem;
using UnityEngine;

[RequireComponent(typeof(AudioSource), typeof(HealthHandler))]
public class PlaySoundOnDamage : MonoBehaviour
{
    [SerializeField] private AudioClip soundEffect;

    private AudioSource _audioSource;
    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        GetComponent<HealthHandler>().OnTakenDamageEvent += PlayHitSound;
    }

    private void PlayHitSound(int damage, Vector2 pos, Vector2 dir)
    {
        _audioSource.PlayOneShot(soundEffect);
    }
}
