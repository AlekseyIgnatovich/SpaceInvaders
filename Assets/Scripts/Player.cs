using UnityEngine;
using Zenject;

[RequireComponent(typeof(ControlComponent))]
[RequireComponent(typeof(ShootingComponent))]
public class Player : MonoBehaviour
{
    [SerializeField] private ControlComponent _controlComponent;
    [SerializeField] private ShootingComponent _shootingComponent;

    [Inject]
    private void Construct(Projectile.Factory projectileFactory)
    {
        _shootingComponent.Init(projectileFactory);
    }
    
    private void Start()
    {
        _controlComponent.OnShot += () =>
        {
            _shootingComponent.Shoot();
        };
    }
    
    public class Factory : PlaceholderFactory<Player>
    {
    }
}
