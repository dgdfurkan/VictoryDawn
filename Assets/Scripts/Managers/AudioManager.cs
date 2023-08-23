using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GunduzDev
{
    [System.Serializable]
    public class Audio
    {
        //public string name;
        public AudioTypes audioType;
        public AudioClip audio;
    }

    //Add all sounds
    public enum AudioTypes
    {
        MusicTellMe, MusicSinnes, MusicWar, Button, Coin, Point, Smash1, Smash2, Smash3, Switch
    }

    public class AudioManager : MonoSingleton<AudioManager>
	{
        // Audio sources
        [SerializeField] private AudioSource musicSource;
        [SerializeField] private AudioSource soundEffectsSource;

        // Volume settings
        private float musicVolume = 1f;
        private float SFXVolume = 1f;

        // Mute settings
        private bool isMusicMuted = false;
        private bool areSoundEffectsMuted = false;

        // Music Clips
        public AudioClip[] MusicClips;

        // Button Clips
        public AudioClip[] ButtonClips;

        [Header("Sounds")]
        [Space(20)]

        public Audio[] SFXAudios;
        public Audio[] MusicAudios;

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            SignalManager.onMusicPlay += PlayMusic2;
            SignalManager.onMusicStop += StopMusic;
            SignalManager.onSFXPlay += PlaySoundEffect2;
            SignalManager.onSFXRandom += PlaySoundEffectRandom;
        }

        private void UnsubscribeEvents()
        {
            SignalManager.onMusicPlay -= PlayMusic2;
            SignalManager.onMusicStop -= StopMusic;
            SignalManager.onSFXPlay -= PlaySoundEffect2;
            SignalManager.onSFXRandom -= PlaySoundEffectRandom;
        }

        private void OnDisable()
        {
            UnsubscribeEvents();
        }

        // Initialization
        private void Start()
        {
            Initialize();
        }

        private void Initialize()
        {
            // Create audio sources
            if (musicSource != null && soundEffectsSource != null) return;
            
            musicSource = gameObject.transform.GetChild(0).GetComponent<AudioSource>();
            
            soundEffectsSource = gameObject.transform.GetChild(1).GetComponent<AudioSource>();
        }

        // Play music
        public void PlayMusic(AudioClip musicClip)
        {
            if (musicClip != null)
            {
                musicSource.clip = musicClip;
                musicSource.loop = true;
                musicSource.volume = musicVolume;
                musicSource.Play();
            }
        }

        // Play music 2
        public void PlayMusic2(AudioTypes type)
        {
            Audio a = Array.Find(MusicAudios, x=>x.audioType == type);

            if (a != null)
            {
                musicSource.clip = a.audio;
                musicSource.loop = true;
                musicSource.volume = musicVolume;
                musicSource.Play();
            }
            else
            {
                Debug.Log("Audio not found");
            }
        }

        // Stop music
        public void StopMusic()
        {
            musicSource.Stop();
        }

        // Play sound effect
        public void PlaySoundEffect(AudioClip soundEffect)
        {
            if (soundEffect != null && !areSoundEffectsMuted)
            {
                soundEffectsSource.PlayOneShot(soundEffect, SFXVolume);
            }
        }

        public void PlaySoundEffect2(AudioTypes type)
        {
            if (areSoundEffectsMuted) return;

            Audio a = Array.Find(SFXAudios, x => x.audioType == type);

            if (a != null)
            {
                soundEffectsSource.PlayOneShot(a.audio, SFXVolume);
            }
            else
            {
                Debug.Log("Audio not found");
            }            
        }

        public void PlaySoundEffectRandom()
        {
            int randomValue = UnityEngine.Random.Range(2, Enum.GetValues(typeof(AudioTypes)).Length);
            Debug.Log(randomValue);
            AudioTypes type = (AudioTypes)randomValue;

            if (areSoundEffectsMuted) return;

            Audio a = Array.Find(SFXAudios, x => x.audioType == type);

            if (a != null)
            {
                soundEffectsSource.PlayOneShot(a.audio, SFXVolume);
                Debug.Log(type);
            }
            else
            {
                Debug.Log("Audio not found");
            }
        }

        // Set music volume
        public void SetMusicVolume(float volume)
        {
            musicVolume = volume;
            if (musicSource.isPlaying)
            {
                musicSource.volume = musicVolume;
            }
        }

        // Set sound effects volume
        public void SetSoundEffectsVolume(float volume)
        {
            SFXVolume = volume;
        }

        // Mute/unmute music
        public void ToggleMusicMute()
        {
            isMusicMuted = !isMusicMuted;
            musicSource.volume = isMusicMuted ? 0f : musicVolume;
        }

        // Mute/unmute sound effects
        public void ToggleSoundEffectsMute()
        {
            areSoundEffectsMuted = !areSoundEffectsMuted;
        }
    }   
}
