using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;
using Utils;

namespace SpaceShooter
{
    public class Done_GameController : MonoBehaviour
    {
        [SerializeField] private SOEvent m_PlayerDeathEvent;
        [SerializeField] private IntEvent m_AddScoreEvent;

        public Text scoreText;
        public Text restartText;
        public Text gameOverText;
        public Text highScoreText;

        private bool gameOver;
        private bool restart;
        private int score;
        private int highScore;

        void Start()
        {
            highScore = PlayerPrefs.GetInt("HighScore");

            gameOver = false;
            restart = false;
            restartText.text = "";
            gameOverText.text = "";
            highScoreText.text = "High Score: " + highScore;
            
            score = 0;
            UpdateScore();
            StartCoroutine(CheckGameOver());

            m_PlayerDeathEvent.Register(GameOver);
            m_AddScoreEvent.Register(AddScore);
        }

        void Update()
        {
            if (restart)
            {
                if (Input.GetKeyDown(KeyCode.R))
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                }
            }
        }

        private void OnDestroy()
        {
            m_PlayerDeathEvent.Unregister(GameOver);
            m_AddScoreEvent.Unregister(AddScore);
        }

        IEnumerator CheckGameOver()
        {
            while (true)
            {
                if (gameOver)
                {
                    restartText.text = "Press 'R' for Restart";
                    restart = true;
                    break;
                }
                yield return null;
            }
        }

        public void AddScore()
        {
            score += m_AddScoreEvent.value;
            UpdateScore();
        }

        void UpdateScore()
        {
            scoreText.text = "Score: " + score;
        }

        public void GameOver()
        {
            gameOverText.text = "Game Over!";
            if (score > highScore)
            {
                highScoreText.text = "New High Score Set: " + score;
                PlayerPrefs.SetInt("HighScore", score);
            }
            gameOver = true;
        }
    }
}