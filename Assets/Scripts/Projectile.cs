using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Vector3 direction = Vector3.up;
    
    [SerializeField] private float _speed = 20f;
    [SerializeField] private float _maxDistance = 6f;
    
    private void Update()
    {
        transform.position += _speed * Time.deltaTime * direction;

        if (transform.position.y > _maxDistance || transform.position.y < -_maxDistance)
        {
            Destroy(gameObject);
        }
    }

    private void CheckCollision(Collider2D other)
    {
        if (gameObject.CompareTag(Constants.EnemyTag))
        {
            Debug.LogError("Collide enemy");
        }
        
        if (gameObject.CompareTag(Constants.PlayerTag))
        {
            Debug.LogError("Collide Player");
        }
        
        Destroy(other.gameObject);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        CheckCollision(other);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        CheckCollision(other);
    }
}