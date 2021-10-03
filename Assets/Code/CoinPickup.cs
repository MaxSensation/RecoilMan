using System;
using UI;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    private AudioSource _source;
    private bool isPickedUp;
    private void Start()
    {
        _source = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isPickedUp || !other.CompareTag("Player")) return;
        ScoreSystemUI.ONScoreAddedEvent?.Invoke(1);
        isPickedUp = true;
        GetComponentInChildren<SpriteRenderer>().enabled = false;
        _source.Play();
        Destroy(gameObject, _source.clip.length);
    }
}
