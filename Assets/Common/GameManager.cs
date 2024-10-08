using System.Collections.Generic;
using PhEngine.Core;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SuperGame
{
    public class GameManager : Singleton<GameManager>
    {
        [Header("Gameplay")]
        [SerializeField] CountdownTimer levelEndTimer;
        [SerializeField] GameplayConfig config;
        [SerializeField] int lifeCount;

        [Header("UI")]
        [SerializeField] HUD hud;

        [Header("BGM")]
        [SerializeField] AudioSource bgm;
        
        bool isPaused;
        bool isGameOver;

        protected override void InitAfterAwake()
        {
            Pause();
            Reset();
            SetupHUD();
            levelEndTimer.duration = config.countdownDuration;
        }
        
        void Reset()
        {
            lifeCount = config.maxLifeCount;
            hud.SetLifeCount(lifeCount);
            hud.SetLevel(LevelManager.Instance.CurrentLevel);
        }
        
        void SetupHUD()
        {
            levelEndTimer.OnDone += EndLevel;
            levelEndTimer.OnTimeChange += time => hud.SetGameEndCountdownTime(time, levelEndTimer.duration);

            hud.OnNext += LevelManager.Instance.MoveToNextLevel;
            hud.OnRestart += Restart;
        }

        void Update()
        {
            if (!isPaused)
                levelEndTimer.PassTime();
        }

        public void StartLevel()
        {
            isGameOver = false;
            levelEndTimer.Start();
            Resume();
            LevelManager.Instance.SetLastPlayedLevel();
            hud.SetGameEndCountdownTime(levelEndTimer.duration, levelEndTimer.duration);
        }

        public void Resume()
        {
            isPaused = false;
            var currentTimeScale = 1f + (config.timeScaleToAdd * ((LevelManager.Instance.CurrentLevel-1)/(LevelManager.Instance.LevelList.Count)));
            Time.timeScale = currentTimeScale;
            bgm.pitch = currentTimeScale;
        }

        void EndLevel()
        {
            AudioManager.Instance.PlayOneShot("victory");
            Pause();
            hud.SetEndGameUIVisible(true, false);
        }

        public void Pause()
        {
            isPaused = true;
            Time.timeScale = 0f;
        }

        public void Lose()
        {
            if (isGameOver)
                return;

            AudioManager.Instance.PlayOneShot("lose");
            isGameOver = true;
            Pause();
            lifeCount--;
            hud.SetLifeCount(lifeCount);
            hud.SetEndGameUIVisible(true, true);
        }

        void Restart()
        {
            if (lifeCount == 0)
            {
                ResetProgress();
            }
            else
            {
                LevelManager.Instance.RestartCurrentLevel();
            }
        }

        public void ResetProgress()
        {
            Reset();
            LevelManager.Instance.LoadFirstLevel();
        }
    }
}