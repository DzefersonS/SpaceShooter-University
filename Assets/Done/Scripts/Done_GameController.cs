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

        public GameObject[] hazards;
        public Vector3 spawnValues;
        public int hazardCount;
        public float spawnWait;
        public float startWait;
        public float waveWait;

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
            StartCoroutine(SpawnWaves());

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

        IEnumerator SpawnWaves()
        {
            yield return new WaitForSeconds(startWait);
            while (true)
            {
                for (int i = 0; i < hazardCount; i++)
                {
                    GameObject hazard = hazards[Random.Range(0, hazards.Length)];
                    Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                    Quaternion spawnRotation = Quaternion.identity;
                    Instantiate(hazard, spawnPosition, spawnRotation);
                    yield return new WaitForSeconds(spawnWait);
                }
                yield return new WaitForSeconds(waveWait);

                if (gameOver)
                {
                    restartText.text = "Press 'R' for Restart";
                    restart = true;
                    break;
                }
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