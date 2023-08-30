using UnityEngine;
using TMPro;

namespace SuperGame.FlappyBird
{
    public class Gameloop : MonoBehaviour
    {
        public GameObject Player;
        public bool GameIsRunning = false;
        
        void Start()
        {
            PauseGame();
            endMenu.SetActive(false);
        }


        void PauseGame()
        {
            GameManager.Instance.Pause();
            Player.GetComponent<Rigidbody2D>().gravityScale = 0;
            GameIsRunning = false;
        }

        public void ResumeGame()
        {
            GameManager.Instance.Resume();
            Player.GetComponent<Rigidbody2D>().gravityScale = 1;
            GameIsRunning = true;
        }

        //---------------------------------------------------UI ZONE
        public GameObject startButton;
        public GameObject endMenu;
        public TextMeshProUGUI hp_text;
        public Hp life_point;

        public void StartGame()
        {
            ResumeGame();
            startButton.SetActive(false);
        }

        public void EndGame()
        {
            PauseGame();
            endMenu.SetActive(true);
        }

        public void RestartGame()
        {
            GameManager.Instance.Lose();
        }

        private void Update()
        {
            hp_text.SetText("Current HP: " + life_point.currenthp.ToString());
        }
    }
}