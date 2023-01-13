using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] float _speed = 1.0f;
    [SerializeField] float _health = 1.0f;
    private GameObject _target;

    // Start is called before the first frame update

    private void Awake()
    {
        _target = GameObject.FindGameObjectWithTag("Player");
    }
    void Start()
    {
        _target = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(_target.transform.position, transform.position) > 0.001f)
        {
            // Move our position a step closer to the target.
            var step = _speed * Time.deltaTime; // calculate distance to move
            transform.position = Vector3.MoveTowards(transform.position, _target.transform.position, step);
        }
    }

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

    private void Die()
    {
        Destroy(gameObject);
    }
}
