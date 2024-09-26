using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{
    public class WaveManager : MonoBehaviour
    {
        public GameObject[] hazards;
        public GameObject boss;
        public Vector3 spawnValues;
        public int hazardCount;
        public float spawnWait;
        public float startWait;
        public float waveWait;
        public int wavesUntilBoss;

        private float m_TimeRemaining = 0.0f;
        private Action<float> m_UpdateAction = default;
        private int m_SpawnsLeft = 0;
        private GameObject m_InstantiatedBoss;
        private int m_WavesUntilBossRemaining;

        private void Awake()
        {
            m_TimeRemaining = startWait + waveWait;
            m_UpdateAction = UpdateCountdown;
            m_WavesUntilBossRemaining = wavesUntilBoss;
        }

        private void Update()
        {
            m_UpdateAction.Invoke(Time.deltaTime);
        }

        private void UpdateCountdown(float deltaTime)
        {
            m_TimeRemaining -= deltaTime;
            if (m_TimeRemaining < 0.0f)
            {
                if (--m_WavesUntilBossRemaining == 0)
                {
                    Vector3 spawnPosition = new Vector3(UnityEngine.Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, 20.0f);
                    Quaternion spawnRotation = Quaternion.identity;
                    m_InstantiatedBoss = Instantiate(boss, spawnPosition, spawnRotation);
                    m_InstantiatedBoss.SetActive(true);
                    m_InstantiatedBoss.transform.SetPositionAndRotation(spawnPosition, spawnRotation);
                    m_UpdateAction = BossWave;
                    return;
                }

                m_SpawnsLeft = hazardCount;
                m_TimeRemaining = waveWait;
                m_UpdateAction = SpawnWaves;
            }
        }

        private void SpawnWaves(float deltaTime)
        {
            m_TimeRemaining -= deltaTime;
            if (m_TimeRemaining < 0.0f)
            {
                GameObject hazard = hazards[UnityEngine.Random.Range(0, hazards.Length)];
                Vector3 spawnPosition = new Vector3(UnityEngine.Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                if (--m_SpawnsLeft == 0)
                {
                    m_UpdateAction = UpdateCountdown;
                    m_TimeRemaining = waveWait;
                }
                else
                {
                    m_TimeRemaining = spawnWait;
                }
            }
        }

        private void BossWave(float deltaTime)
        {
            if (!m_InstantiatedBoss)
            {
                m_UpdateAction = UpdateCountdown;
                m_TimeRemaining = waveWait;
                m_WavesUntilBossRemaining = wavesUntilBoss;
            }
        }
    }
}