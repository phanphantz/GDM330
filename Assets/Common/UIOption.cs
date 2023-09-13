using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace SuperGame
{
    public class UIOption : MonoBehaviour
    {
        [SerializeField] Button restartButton;
        [SerializeField] Button resumeButton;
        [SerializeField] Slider slider;

        [SerializeField] UnityEvent onOpen = new UnityEvent();
        
        void Awake()
        {
            GameManager.Instance.Pause();
            
            resumeButton.onClick.AddListener(Resume);
            restartButton.onClick.AddListener(Restart);
            slider.onValueChanged.AddListener(SetVolume);
            
            onOpen.Invoke();
        }

        void SetVolume(float volume)
        {
            AudioManager.Instance.SetMusicVolume(volume);
        }

        void Resume()
        {
            GameManager.Instance.Resume();
            gameObject.SetActive(false);
        }

        void Restart()
        {
            GameManager.Instance.ResetProgress();
            gameObject.SetActive(false);
        }
    }
}