using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] GameObject _bullet;
    [SerializeField] float _speed=1;
    [SerializeField] float _speedRotated = 10;
 
   
    [SerializeField] private Transform _bulletPosition;
    private void FixedUpdate()
    {
        Move();
        Fire();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
            GameController.Counts(gameObject.tag);
        }
    }
    private void Move()
    {
        if (Input.GetKey(KeyCode.W))
            transform.position += transform.forward*_speed*Time.deltaTime;
        if (Input.GetKey(KeyCode.S))
            transform.position -= transform.forward * _speed * Time.deltaTime;
        if (Input.GetKey(KeyCode.D))
            transform.Rotate(Vector3.up * _speedRotated * Time.deltaTime);
        if (Input.GetKey(KeyCode.A))
            transform.Rotate(Vector3.down * _speedRotated * Time.deltaTime);
    }
    private void Fire()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {             
            GameObject bullet = Instantiate(_bullet);
            bullet.transform.position = _bulletPosition.position;
            bullet.transform.rotation = transform.rotation;         
        }
    }    
}
