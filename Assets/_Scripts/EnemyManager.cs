
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{

    [SerializeField] float _spawnRate = 5.0f;
    [SerializeField] Enemy _simpleEnemyPrefab;
    [SerializeField] float _distanceFromPlayer;
    [SerializeField] float _totalEnemiesPerWave;
    [SerializeField] GameObject _player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        while (Enemy.Enemycount < 10)
        {
            Debug.Log("Enemy count" + Enemy.Enemycount);
            SpawnEnemy();
        }

     
           
       
        
        //SpawnWave();
        // compute number of enemies to spawn

        // align enemies

        // compute random position

        // instantiate simple enemies away from player


    }

    private void CheckCollision()
    {
        throw new NotImplementedException();
    }

    private void SpawnWave()
    {
       
    }

    private void SpawnEnemy()
    {
        Debug.Log("Enemy number" + Enemy.Enemycount);
        Vector3 desiredPos = UnityEngine.Random.insideUnitCircle * 40;
        Enemy enemy = Instantiate(_simpleEnemyPrefab, _player.transform.position * UnityEngine.Random.insideUnitCircle * 40, Quaternion.identity);
        enemy.Setup();
        
    }
}
