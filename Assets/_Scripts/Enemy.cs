using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static int Enemycount = 0;
  
    [SerializeField] float _speed = 1.0f;
    [SerializeField] float _health = 1.0f;
    [SerializeField] float _avoidanceRadius = 1.0f;
    private Collider2D _collider;
    private GameObject _target;
    private Rigidbody2D _rb2d;

    public Vector3 _avoidanceDirection;
    public Collider2D EnemyCollider { get { return _collider; } }
    public float AvoidanceRadius { get { return _avoidanceRadius; } }
    


    /// <summary>
    /// Init method
    /// </summary>
    /// <param name="player"></param>
    public void Setup(GameObject player)
    {
        //keep trace of enemy number
        Enemycount += 1;

        _target = player;
        _collider = GetComponent<Collider2D>();
        _rb2d = GetComponent<Rigidbody2D>();

    }

    /// <summary>
    /// Set avoidance direction
    /// </summary>
    /// <param name="avoidance"></param>
    public void SetAvoidance(Vector2 avoidance)
    {
        _avoidanceDirection = avoidance;
    }
    // Update is called once per frame
    void Update()
    {

        //ApplyAvoidenceMovement();
       
    }


    /// <summary>
    /// Apply avoidence movement
    /// </summary>
    private void ApplyAvoidenceMovement()
    {
        // speed up movement to avoid overlapped object
        transform.position += _avoidanceDirection * (_speed * 1.5f) * Time.deltaTime;
    }




    /// <summary>
    /// Simple damage method
    /// </summary>
    /// <param name="amount"></param>
    public void TakeDamage(float amount)
    {
        Debug.Log("Take damage");
        if(_health <= 0)
        {
            Die();
            return;
        }
        _health -= amount;
    }


    /// <summary>
    /// Destroy object
    /// </summary>
    private void Die()
    {
        Enemycount--;
        Destroy(gameObject);
    }


    private void FixedUpdate()
    {
        if (Vector2.Distance(_target.transform.position, transform.position) > 1f)
        {
            //OLD move enemy near player
            //transform.position -= (transform.position - _target.transform.position).normalized * _speed * Time.deltaTime;

            Vector2 newPosition = Vector2.MoveTowards(transform.position, _target.transform.position, Time.deltaTime * _speed);
            _rb2d.MovePosition(newPosition);

        }
    }

}
