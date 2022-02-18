using System.Collections;
using UnityEngine.AI;
using UnityEngine;

public class Bot : MonoBehaviour
{
    [SerializeField] float _angle = 45;
    [SerializeField] private Transform _playerPosition;
    [SerializeField] private Transform _bulletPosition;
    [SerializeField] GameObject _bullet;    
    NavMeshAgent _bot;


    private void Start()
    {
        StartCoroutine(Move());
        StartCoroutine(Fire());
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
            GameController.Counts(gameObject.tag);
        }
    }




    IEnumerator Fire()
    {
        if (Vector3.Angle(transform.forward, _playerPosition.position - transform.position) <= _angle)
        {
            GameObject bullet = Instantiate(_bullet);
            bullet.transform.position = _bulletPosition.position;
            bullet.transform.rotation = transform.rotation;           
        }
        yield return new WaitForSeconds(1.5f);
        StartCoroutine(Fire());
    }

    IEnumerator Move()
    {
        yield return new WaitForSeconds(0.5f);
        _bot = GetComponent<NavMeshAgent>();
        _bot.destination = _playerPosition.position;
        StartCoroutine(Move());
    }
    


}
