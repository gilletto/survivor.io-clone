using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private float _speed = 5.0f;
    [SerializeField] private float _health = 1f;
    [SerializeField] private float _stamina = 1f;
    [SerializeField] private float _defence = 0f;
    [SerializeField] private GameObject _projectilePrefab;
    [SerializeField] private LayerMask _enemyLayer;
    private Vector3 _movementDirection;


    private float _horizontal;
    private float _vertical;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        _horizontal = Input.GetAxis("Horizontal");
        _vertical = Input.GetAxis("Vertical");

        // direction for simple projectile trajectory
        _movementDirection = new Vector3(_horizontal, _vertical, 0);

        // if we are not moving, take orientation
        if (_movementDirection.normalized == Vector3.zero)
        {

            _movementDirection = transform.localScale.x < 0 ? transform.right : -transform.right;
        }

        // shoot simple directional projectile
        if (Input.GetKeyDown(KeyCode.Space)){

            //instantiate projectile
            RaycastHit2D raycasthit = Physics2D.Raycast(transform.position + _movementDirection.normalized, _movementDirection.normalized, 100f, _enemyLayer);
            if (raycasthit.collider != null)
            {

                Debug.Log("projectile hit!" + raycasthit.collider.gameObject.name);
                Enemy enemy = raycasthit.collider.GetComponent<Enemy>();
                enemy?.TakeDamage(2f);
                GameObject projectile = Instantiate(_projectilePrefab, transform.position + _movementDirection.normalized, Quaternion.identity);
                Projectile projectile_script = projectile.GetComponent<Projectile>();

                // setup variables
                projectile_script.Setup(_movementDirection.normalized, 20.0f);
            }
            else
            {
                GameObject projectile = Instantiate(_projectilePrefab, transform.position + _movementDirection.normalized, Quaternion.identity);
                Projectile projectile_script = projectile.GetComponent<Projectile>();

                // setup variables
                projectile_script.Setup(_movementDirection.normalized, 20.0f);
            }



            // raycast check


        }
    }

    private void FixedUpdate()
    {
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
        transform.Translate(movement *  _speed * Time.deltaTime);
    }
}
