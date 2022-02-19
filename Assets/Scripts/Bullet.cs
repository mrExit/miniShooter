using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] [Range (0.5f, 10f)] float _speed = 2;
    Ray ray, ray1;
    RaycastHit hit;

    private void Update()
    {
        Move();
    }
    void FixedUpdate()
    {
        
        
        Direction();      
    }    
    private void OnCollisionEnter(Collision collision)
    {
        Rotate(); 
    }

    private void OnBecameInvisible()
    {    
        Destroy(gameObject);
    }
    private void Direction()
    {
        ray = new Ray(transform.position, transform.forward);

        if (Physics.Raycast(ray, out hit, 100))
        {
            ray1 = new Ray(hit.point, Vector3.Reflect(ray.direction, hit.normal));

        }
    }
    private void Move()
    {
        transform.position += transform.forward * _speed * Time.deltaTime;
    }
    
    private void Rotate()
    {
        transform.rotation = Quaternion.LookRotation(ray1.direction);
    }
}
