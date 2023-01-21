
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{

    [SerializeField] float _spawnRate = 5.0f;
    [SerializeField] Enemy _simpleEnemyPrefab;
    [SerializeField] GameObject _player;
    [SerializeField] Transform _gemPrefab;
    List<Enemy> _enemies = new List<Enemy>();
   
    // Update is called once per frame
    void Update()
    {
        // TODO: change with a couroutine
        // spawn a fixed number of enemy
        if (Enemy.Enemycount < 20)
        {
            SpawnEnemy();
        }
    }


    private void SpawnEnemy()
    {
        Vector3 desiredPos = UnityEngine.Random.insideUnitCircle * 40;
        Enemy enemy = Instantiate(_simpleEnemyPrefab, _player.transform.position +  desiredPos, Quaternion.identity);
        enemy.name = "Enemy" + Enemy.Enemycount;
        enemy.Setup(_player, _gemPrefab);
        _enemies.Add(enemy);
        
    }

    public void RemoveEnemy(Enemy enemy)
    {
        _enemies.Remove(enemy);
    }

    public void DisposeAll()
    {
        foreach(Enemy enem in _enemies)
        {
            Destroy(enem.gameObject);
        }
        Enemy.Enemycount = 0;
        _enemies.Clear();
    }
}
