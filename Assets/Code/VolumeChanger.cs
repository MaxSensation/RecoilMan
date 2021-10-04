using System;
using CoreSystem.DataSystem;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class VolumeChanger : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private VolumeChannel channel;
    [SerializeField] private FloatDataType savedVolume;

    private Slider _slider;
    private void Awake()
    {
        _slider = GetComponent<Slider>();
        _slider.onValueChanged.AddListener(delegate {
            ChangeVolume(Mathf.Log10(_slider.value) * 20);
            savedVolume.Data = _slider.value;
        });
        if (savedVolume.Data < 1f) _slider.value = savedVolume.Data;
    }

    private void ChangeVolume(float vol)
    {
        switch (channel)
        {
            case VolumeChannel.Master:
                audioMixer.SetFloat("Master", vol);
                break;
            case VolumeChannel.Music:
                audioMixer.SetFloat("Music", vol);
                break;
            case VolumeChannel.SoundEffects:
                audioMixer.SetFloat("SoundEffect", vol);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}

internal enum VolumeChannel
{
    Master,
    Music,
    SoundEffects
}
