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

    public Vector3 _avoidanceDirection;
    public Collider2D EnemyCollider { get { return _collider; } }
    public float AvoidanceRadius { get { return _avoidanceRadius; } }
    

    public void Setup(GameObject player)
    {
        //keep trace of enemy number
        Enemycount += 1;

        _target = player;
        _collider = GetComponent<Collider2D>();

    }

    public void SetAvoidance(Vector2 avoidance)
    {
        _avoidanceDirection = avoidance;
    }
    // Update is called once per frame
    void Update()
    {

        // Move toward target(player)


        transform.position += _avoidanceDirection * (_speed * 1.5f)* Time.deltaTime;

        if (Vector2.Distance(_target.transform.position, transform.position) > 0.001f)
        {
            transform.position -= (transform.position - _target.transform.position).normalized * _speed * Time.deltaTime;


            // Move our position a step closer to the target.
            //var step = _speed * Time.deltaTime; // calculate distance to move
            //transform.position = Vector3.MoveTowards(transform.position - _avoidanceDirection, _target.transform.position, step);
        }
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


    /// <summary>
    /// Show avoidance circle
    /// </summary>
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
     //Use the same vars you use to draw your Overlap SPhere to draw your Wire Sphere.
     Gizmos.DrawWireSphere(transform.position, _avoidanceRadius);
    }
}
