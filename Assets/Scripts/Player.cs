using UnityEngine;

[RequireComponent(typeof(ControlComponent))]
[RequireComponent(typeof(ShootingComponent))]
public class Player : MonoBehaviour
{
    [SerializeField] private ControlComponent _controlComponent;
    [SerializeField] private ShootingComponent _shootingComponent;

    private void Start()
    {
        _controlComponent.OnShot += () =>
        {
            _shootingComponent.Shoot();
        };
    }
}
