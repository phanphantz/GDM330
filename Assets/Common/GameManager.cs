using System;
using System.Collections.Generic;
using PhEngine.Core;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SuperGame
{
    public class GameManager : Singleton<GameManager>
    {
        [SerializeField] CountdownTimer levelEndTimer;
        [SerializeField] float timeScaleToAdd = 0.1f;
        [SerializeField] int maxLifeCount = 3;
        [SerializeField] int lifeCount;
        [SerializeField] int currentLevel = 0;

        [SerializeField] List<string> levelList = new List<string>();
        [SerializeField] string lastPlayedScene;

        [SerializeField] HUD hud;

        protected override void InitAfterAwake()
        {
            Reset();
            SetupHUD();
            StartLevel();
        }

        void SetupHUD()
        {
            levelEndTimer.OnDone += EndLevel;
            levelEndTimer.OnTimeChange += time => hud.SetGameEndCountdownTime(time, levelEndTimer.duration);

            hud.OnNext += MoveToNextLevel;
            hud.OnRestart += Restart;
        }

        void Update()
        {
            levelEndTimer.PassTime();
        }

        void StartLevel()
        {
            levelEndTimer.Start();
            Time.timeScale = 1f + (timeScaleToAdd * currentLevel);
            lastPlayedScene = levelList[currentLevel];
            hud.SetGameEndCountdownTime(levelEndTimer.duration, levelEndTimer.duration);
        }
        
        void EndLevel()
        {
            Time.timeScale = 0f;
            hud.SetEndGameUIVisible(true, false);
        }

        public void Lose()
        {
            Time.timeScale = 0f;
            lifeCount--;
            if (lifeCount == 0)
                hud.SetEndGameUIVisible(true, true);
            
            hud.SetLifeCount(lifeCount);
        }

        public void Restart()
        {
            if (lifeCount == 0)
            {
                Reset();
                LoadScene(levelList[0]);
            }
            else
            {
                LoadScene(levelList[currentLevel]);
            }
        }

        public void Reset()
        {
            lifeCount = maxLifeCount;
            currentLevel = 0;
            
            hud.SetLifeCount(lifeCount);
            hud.SetLevel(currentLevel);
        }

        public void MoveToNextLevel()
        {
            currentLevel++;
            if (currentLevel >= levelList.Count)
                currentLevel = 0;
            
            hud.SetLevel(currentLevel);
            LoadScene(levelList[currentLevel]);
        }

        void LoadScene(string sceneName)
        {
            var loadSceneAsync = SceneManager.LoadSceneAsync(sceneName);
            loadSceneAsync.completed += (op) => StartLevel();
        }
    }
}