using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public static int ProjectileCount = 0;
    [SerializeField] float _speed = 1.0f;
    private Vector3 _direction;
    
    public void Setup(Vector3 direction, float speed)
    {
        ProjectileCount++;
        gameObject.name = "Projectile " + ProjectileCount;
        _direction = direction;
        _speed = speed;
        Destroy(gameObject, 3f);
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(_direction * _speed * Time.deltaTime);
    }

}
