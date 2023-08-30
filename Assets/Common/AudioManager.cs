using System;
using System.Collections.Generic;
using PhEngine.Core;
using UnityEngine;

namespace SuperGame
{
    public class AudioManager : Singleton<AudioManager>
    {
        [SerializeField] AudioSource audioSource;
        [SerializeField] List<AudioRecord> recordList = new List<AudioRecord>();
        
        protected override void InitAfterAwake()
        {
            
        }

        public void Play(string id)
        {
            //audioSource.Play(targetClip);
        }
    }

    [Serializable]
    public class AudioRecord
    {
        public string id;
        public AudioClip clip;
    }
}