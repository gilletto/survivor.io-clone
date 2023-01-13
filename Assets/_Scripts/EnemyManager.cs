
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{

    [SerializeField] float _spawnRate = 5.0f;
    [SerializeField] GameObject _simpleEnemyPrefab;
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
        
        //SpawnWave();
        // compute number of enemies to spawn

        // align enemies

        // compute random position

        // instantiate simple enemies away from player

        SpawnEnemy();

    }

    private void SpawnWave()
    {
       
    }

    private void SpawnEnemy()
    {
        Vector3 desiredPos =  Random.insideUnitCircle * 40;
        Instantiate(_simpleEnemyPrefab, _player.transform.position * Random.insideUnitCircle * 40, Quaternion.identity);
        
    }
}
