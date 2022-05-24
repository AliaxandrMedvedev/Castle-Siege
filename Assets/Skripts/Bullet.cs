using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _explosionForce;

    private Vector3 _moveDirection;


    private void Start()
    {
        _moveDirection = Vector3.forward;
    }

    private void Update()
    {
        transform.Translate(_moveDirection * _speed * Time.deltaTime);      // движение пули вперед
    }


    private void OnTriggerEnter(Collider other)  // попадание в блок башни
    {
        if (other.TryGetComponent(out Block block))
        {
            block.Break();         // уничтожение блока
            Destroy(gameObject); // уничтожение пули
        }
        if (other.TryGetComponent(out Obstacle obstacle))  // попадание в препятствие
        {     
            Bounce();
        }
    }

    private void Bounce()
    {
        _speed = 0;
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        rigidbody.isKinematic = false;
        rigidbody.AddExplosionForce(_explosionForce, transform.position + new Vector3(0, -1, 1), 70);
        Collider collider = GetComponent<Collider>();
        collider.isTrigger = true;
        StartCoroutine(DestroyTimer());
    }

    // уничтожение пули через время
    IEnumerator DestroyTimer()         
    {
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }
}
