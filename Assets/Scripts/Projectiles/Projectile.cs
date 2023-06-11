using UnityEngine;
using Zenject;

public class Projectile : MonoBehaviour
{
    protected SignalBus _signalBus;

    private LevelBorders _levelBorders;

    [SerializeField] private float _speed = 20f;
    [SerializeField] private Vector3 _direction = Vector3.up;

    [Inject]
    public void Construct(SignalBus signalBus, LevelBorders levelBorders)
    {
        _signalBus = signalBus;
        _signalBus.Subscribe<RestartLevelSignal>(Kill);

        _levelBorders = levelBorders;
    }

    void Kill()
    {
        Destroy(gameObject);
    }

    private void Update()
    {
        transform.position += _speed * Time.deltaTime * _direction;

        if (transform.position.y > _levelBorders.Height || transform.position.y < -_levelBorders.Height)
        {
            Destroy(gameObject);
        }
    }

    protected virtual void CheckCollision(Collider2D other) { }

    private void OnTriggerEnter2D(Collider2D other)
    {
        CheckCollision(other);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        CheckCollision(other);
    }

    private void OnDestroy()
    {
        _signalBus.Unsubscribe<RestartLevelSignal>(Kill);
    }
}
