using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static int Enemycount = 0;
    
    [SerializeField] float _speed = 1.0f;
    [SerializeField] float _health = 1.0f;
    [SerializeField] Transform _gemPrefab;
    private GameObject _target;
    private Rigidbody2D _rb2d;



    /// <summary>
    /// Init method
    /// </summary>
    /// <param name="player"></param>
    public void Setup(GameObject player, Transform gem)
    {
        //keep trace of enemy number
        Enemycount += 1;
        _target = player;
        _rb2d = GetComponent<Rigidbody2D>();
        _gemPrefab = gem;

    }

    /// <summary>
    /// Simple damage method
    /// </summary>
    /// <param name="amount"></param>
    public void TakeDamage(float amount)
    {
        _health -= amount;
        if (_health <= 0)
        {
            Die();

            // TODO: change with event delegation

            // Change enemy statistics
            GameManager.Instance.IncreaseEnemyKill();

            // Gain experience
            GameManager.Instance.IncreaseExperience(5);

            //Drop gem or reward
            Instantiate(_gemPrefab, transform.position, Quaternion.identity);
            
            return;
        }
    }


    /// <summary>
    /// Destroy object
    /// </summary>
    private void Die()
    {
        Enemycount--;
        //drop exp gems
        Destroy(gameObject);
    }


    private void FixedUpdate()
    {
        Vector2 newPosition = Vector2.MoveTowards(transform.position, _target.transform.position, Time.deltaTime * _speed);
        _rb2d.MovePosition(newPosition);
    }

}
