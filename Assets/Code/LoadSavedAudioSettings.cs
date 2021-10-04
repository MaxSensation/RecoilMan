using System;
using CoreSystem.DataSystem;
using UnityEngine;
using UnityEngine.Audio;

public class LoadSavedAudioSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private FloatDataType masterVolume;
    [SerializeField] private FloatDataType musicVolume;
    [SerializeField] private FloatDataType soundEffectVolume;

    private bool _hasLoadedSettings;

    private void Update()
    {
        if (_hasLoadedSettings) return;
        audioMixer.SetFloat("Master", Mathf.Log10(masterVolume.Data) * 20);
        audioMixer.SetFloat("Music", Mathf.Log10(musicVolume.Data) * 20);
        audioMixer.SetFloat("SoundEffect", Mathf.Log10(soundEffectVolume.Data) * 20);
        
        audioMixer.GetFloat("Master", out var masterVal);
        audioMixer.GetFloat("Music", out var musicVal);
        audioMixer.GetFloat("SoundEffect", out var soundFXVal);
        
        if (Math.Abs(masterVal - Mathf.Log10(masterVolume.Data) * 20) < 0.1f && 
            Math.Abs(musicVal - Mathf.Log10(musicVolume.Data) * 20) < 0.1f && 
            Math.Abs(soundFXVal - Mathf.Log10(soundEffectVolume.Data) * 20) < 0.1f)
            _hasLoadedSettings = true;
    }
}
