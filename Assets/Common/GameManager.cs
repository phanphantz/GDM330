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
        [SerializeField] int maxLifeCount = 3;
        [SerializeField] int lifeCount;
        [SerializeField] float timeScaleToAdd = 0.1f;
        
        [Header("Level")]
        [SerializeField] int currentLevel = 1;
        [SerializeField] int currentScene = 0;
        [SerializeField] List<string> levelList = new List<string>();
        [SerializeField] string lastPlayedScene;

        [Header("UI")]
        [SerializeField] HUD hud;
        
        bool isPaused;
        bool isGameOver;

        protected override void InitAfterAwake()
        {
            Reset();
            SetupHUD();
            StartLevel();
        }
        
        void Reset()
        {
            lifeCount = maxLifeCount;
            currentLevel = 1;
            currentScene = 0;
            hud.SetLifeCount(lifeCount);
            hud.SetLevel(currentLevel);
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
            if (!isPaused)
                levelEndTimer.PassTime();
        }

        void StartLevel()
        {
            isGameOver = false;
            levelEndTimer.Start();
            Resume();
            lastPlayedScene = levelList[currentScene];
            hud.SetGameEndCountdownTime(levelEndTimer.duration, levelEndTimer.duration);
        }

        public void Resume()
        {
            isPaused = false;
            Time.timeScale = 1f + (timeScaleToAdd * currentLevel);
        }

        void EndLevel()
        {
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
                Reset();
                LoadScene(levelList[0]);
            }
            else
            {
                LoadScene(levelList[currentScene]);
            }
        }
        
        void MoveToNextLevel()
        {
            currentLevel++;
            currentScene++;
            if (currentScene >= levelList.Count)
                currentScene = 0;
            
            hud.SetLevel(currentLevel);
            LoadScene(levelList[currentScene]);
        }

        void LoadScene(string sceneName)
        {
            var loadSceneAsync = SceneManager.LoadSceneAsync(sceneName);
            loadSceneAsync.completed += (op) => StartLevel();
        }
    }
}