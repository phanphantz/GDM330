using System;
using System.Collections.Generic;
using PhEngine.Core;
using UnityEngine;

namespace SuperGame
{
    public class AudioManager : Singleton<AudioManager>
    {
        [SerializeField] AudioSource musicSource;
        [SerializeField] AudioSource audioSource;
        [SerializeField] List<AudioRecord> recordList = new List<AudioRecord>();
        
        protected override void InitAfterAwake()
        {
            
        }

        public void PlayOneShot(string id)
        {
            foreach (var record in recordList)
            {
                if (record.id == id)
                {
                    var newAudioSource = Instantiate(audioSource, transform, true);
                    newAudioSource.clip = record.clip;
                    newAudioSource.Play();
                }
            }
        }

        public void SetMusicVolume(float volume)
        {
            musicSource.volume = volume * 0.5f;
        }
    }

    [Serializable]
    public class AudioRecord
    {
        public string id;
        public AudioClip clip;
    }
}