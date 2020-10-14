using System.Collections;
using System.Collections.Generic;
using Entities;
using Helper;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Managers
{
    public class SpawnManager : BehaviourSingleton<SpawnManager>
    {
        [SerializeField] private int enemyTimeToSpawn = 3;
        [SerializeField] private float powerUpMinTimeToSpawn = 3;
        [SerializeField] private float powerUpMaxTimeToSpawn = 30;
        [SerializeField] private GameObject enemyPrefab;
        [SerializeField] private List<GameObject> powerUps;
        [SerializeField] private Transform enemyContainer;
        [SerializeField] private Transform powerUpContainer;
        [SerializeField] private Player playerScript;

        private Coroutine _spawnEnemy;
        private Coroutine _spawnPowerUp;
        
        protected override void Init()
        {
            playerScript.SetOnPlayerDeath(OnPlayerDeath);
        }
        
        private void Start()
        {
            _spawnEnemy = StartCoroutine(SpawnEnemyCoroutine());
            _spawnPowerUp = StartCoroutine(SpawnPowerUpCoroutine());
        }

        private void OnDisable()
        {
            StopCoroutine(_spawnEnemy);
            StopCoroutine(_spawnPowerUp);
        }

        private IEnumerator SpawnEnemyCoroutine()
        {
            while (true)
            {
                var position = new Vector3(Random.Range(ScreenValues.LeftLimit, ScreenValues.RightLimit), 
                    ScreenValues.TopLimit + ScreenValues.OffScreenEffectsLength, 
                    0);
                
                var enemy =
                    GameObjectPoolManager.Instance.RequestObject(enemyPrefab, position, Quaternion.identity,
                        enemyContainer);
                enemy.SetActive(true);

                yield return new WaitForSeconds(enemyTimeToSpawn);
            }
        }

        private IEnumerator SpawnPowerUpCoroutine()
        {                
            if (powerUps.Count < 1)
                yield break;
            
            while (true)
            {
                yield return new WaitForSeconds(Random.Range(powerUpMinTimeToSpawn, powerUpMaxTimeToSpawn));

                var powerUp = powerUps[Random.Range(0, powerUps.Count)];
                var position = new Vector3(Random.Range(ScreenValues.LeftLimit, ScreenValues.RightLimit), 
                    ScreenValues.TopLimit + ScreenValues.OffScreenEffectsLength);

                var instance = Instantiate(powerUp, position, Quaternion.identity);

                instance.transform.parent = powerUpContainer;
            }
        }

        private void OnPlayerDeath()
        {
            gameObject.SetActive(false);
        }
    }
}