
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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // spawn a fixed number of enemy
        while (Enemy.Enemycount < 10)
        {
            Debug.Log("Enemy count" + Enemy.Enemycount);
            SpawnEnemy();
        }

        // search for nearby enemies
        //foreach(Enemy enemy in _enemies)
        //{
        //    List<Transform> context = GetNearbyObjects(enemy);

        //    //Debugging avoidance radius : red too nearby enemy, white 0 nearby enemy
        //    SpriteRenderer[] renderers = enemy.GetComponentsInChildren<SpriteRenderer>();
        //    foreach (SpriteRenderer rend in renderers)
        //    {
        //        rend.color = Color.Lerp(Color.white, Color.red, context.Count / 6f);
        //    }

        //    Vector2 avoidanceMovement = Vector2.zero;
        //    int nAvoid = 0;

        //    foreach(Transform item in context)
        //    {
        //        // check if enemy is inside avoidanceCircle
        //        if (Vector2.SqrMagnitude(item.position - enemy.transform.position) < enemy.AvoidanceRadius){
        //            // add  number of element to avoid
        //            // get direction from nearby enemy or enemies
        //            // invert direction
        //            // set movement
        //            nAvoid++;
        //            var directionToNearbyEnemy = item.position - enemy.transform.position;
        //            var inverseDirection = -directionToNearbyEnemy;
        //            avoidanceMovement += (Vector2)inverseDirection;
        //        }
         
        //    }
        //    // divide movement by number of element to avoid to get smooth movement
        //    if(nAvoid > 0)
        //    {
        //        avoidanceMovement /= nAvoid;
        //    }
        //    // set enemy avoidance movement
        //    enemy.SetAvoidance(avoidanceMovement);
       
        //}

        // compute number of enemies to spawn
        //SpawnWave();


    }

    /// <summary>
    ///  Search for nearby enemies
    /// </summary>
    /// <returns></returns>
    private List<Transform> GetNearbyObjects(Enemy enemy)
    {
        List<Transform> context = new List<Transform>();
        Collider2D[] contextColliders = Physics2D.OverlapCircleAll(enemy.transform.position, enemy.AvoidanceRadius);
        foreach (Collider2D c in contextColliders)
        {
            if (c != enemy.EnemyCollider)
            {
                context.Add(c.transform);
            }
        }
        return context;
    }

    private void SpawnWave()
    {
       
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
