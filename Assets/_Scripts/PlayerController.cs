using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private float _speed = 5.0f;
    [SerializeField] private float _health = 1f;
    [SerializeField] private GameObject _projectilePrefab;
    [SerializeField] private float _fireRate = 3f;
    [SerializeField] private LayerMask _enemyLayer;
    private Vector3 _movementDirection;
    private float _nextFireTime = 3f;


    private float _horizontal;
    private float _vertical;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Fire();
    }

    private void Fire()
    {
        // check if we can fire
        if(_nextFireTime > Time.time) return;
        // reset next fire time
        _nextFireTime = Time.time + _fireRate;

        // compute direction of projectile
        var nearest = GetNearestEnemy(1f);

        // compute direction
        _movementDirection = (nearest.position - transform.position);

        // cast ray for enemy hit
        RaycastHit2D raycasthit = Physics2D.Raycast(transform.position + _movementDirection.normalized, _movementDirection.normalized, 100f, _enemyLayer);
        
        // if we hit enemy
        if (raycasthit.collider != null)
        {

            Debug.Log("projectile hit!" + raycasthit.collider.gameObject.name);

            // Damage enemy
            Enemy enemy = raycasthit.collider.GetComponent<Enemy>();
            enemy?.TakeDamage(10f);

            // instantiate projectile
            GameObject projectile = Instantiate(_projectilePrefab, transform.position + _movementDirection.normalized, Quaternion.identity);
            Projectile projectile_script = projectile.GetComponent<Projectile>();

            // setup projectile variables(direction and speed)
            projectile_script.Setup(_movementDirection.normalized, 20.0f);
        }
        else
        {
            GameObject projectile = Instantiate(_projectilePrefab, transform.position + _movementDirection.normalized, Quaternion.identity);
            Projectile projectile_script = projectile.GetComponent<Projectile>();

            // setup variables
            projectile_script.Setup(_movementDirection.normalized, 20.0f);
        }

    }

    /// <summary>
    /// Get nearest enemy base on radius
    /// </summary>
    /// <param name="radius"></param>
    /// <returns></returns>
    private Transform GetNearestEnemy(float radius)
    {
        var rad = radius;
        // Get all enemies inside OverlapCircleAll  and return the nearest
        Transform  nearest;
        float tempDistance = 0;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, radius, _enemyLayer);

        if (colliders.Length > 0)
        {
            // set first collider as the nearest
            nearest = colliders[0].transform;
            tempDistance = Vector3.Distance(nearest.position, transform.position);

            foreach (Collider2D item in colliders)
            {
                // check if distance is smaller than stored one
                var dist = Vector3.Distance(nearest.position, transform.position);
                if (dist < tempDistance)
                {
                    nearest = item.transform;
                    tempDistance = dist;
                }
            }
            // return enemy
            Debug.Log("Nearest enemy is " + nearest.name);
            return nearest;
        }
        else
        {
            rad++;
            return ComputeProjectileDirection(rad);
        }
        return null;
    }

    private void Move()
    {
        // Get input from player
        _horizontal = Input.GetAxis("Horizontal");
        _vertical = Input.GetAxis("Vertical");

        // set movement direction
        Vector2 movement = new Vector3(_horizontal, _vertical, 0);


        // invert direction based on input
        if (_horizontal > 0)
        {
            transform.localScale = new Vector3(-1f, 1, 1);
        }
        else if (_horizontal < 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        // move player
        transform.Translate(movement * _speed * Time.deltaTime);
    }
}
