using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    [SerializeField] Transform _player;
    [SerializeField] Vector3 _offset;
    [SerializeField] float _smoothSpeed = 0.125f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        Vector3 desiredPosition = _player.position + _offset;
        Vector3 smoothPosition = Vector3.Lerp(transform.position, desiredPosition, _smoothSpeed);
        transform.position = new Vector3(smoothPosition.x, smoothPosition.y, transform.position.z);

    }
}
