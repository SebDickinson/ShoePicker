using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class Soundmanager : MonoBehaviour
    {
        public static Soundmanager instance;

        public AudioSource interactionAudioSource;

        public AudioSource ambientSound;


        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(this);
            }
            else
            {
                Destroy(this);
            }
        }

        private void OnEnable()
        {
            PlayBackgroundSounds();
        }

        /// <summary>
        /// Play a single sound
        /// </summary>
        public void PlaySound(AudioClip clip)
        {
            if (clip && interactionAudioSource)
            {
                interactionAudioSource.PlayOneShot(clip);
            }
        }

        /// <summary>
        /// Play a single sound
        /// </summary>
        public void PlaySound(AudioClip clip, AudioSource audioSource)
        {
            if (clip && audioSource)
            {
                audioSource.PlayOneShot(clip);
            }
        }

        public void StopBackgroundSound()
        {
            ambientSound.Stop();
        }

        public void PlayBackgroundSounds()
        {
            ambientSound.Play();
        }
    }

