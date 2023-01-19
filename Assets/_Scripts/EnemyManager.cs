
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
    List<Enemy> _enemies = new List<Enemy>();
   
    // Update is called once per frame
    void Update()
    {
        // spawn a fixed number of enemy
        if (Enemy.Enemycount < 10)
        {
            Debug.Log("Enemy count" + Enemy.Enemycount);
            SpawnEnemy();
        }
    }


    private void SpawnEnemy()
    {
        Debug.Log("Enemy number" + Enemy.Enemycount);
        Vector3 desiredPos = UnityEngine.Random.insideUnitCircle * 40;
        Enemy enemy = Instantiate(_simpleEnemyPrefab, _player.transform.position * UnityEngine.Random.insideUnitCircle * 5, Quaternion.identity);
        enemy.name = "Enemy" + Enemy.Enemycount;
        enemy.Setup(_player);
        _enemies.Add(enemy);
        
    }
}
