using UnityEngine;

public class ShootingComponent : MonoBehaviour
{
	[SerializeField] private GameObject _projectilePrefab;

	private Projectile.Factory _projectileFactory;
	
	public void Init(Projectile.Factory projectileFactory)
	{
		_projectileFactory = projectileFactory;
	}
	
	public void Shoot()
	{
		var projectile = _projectileFactory.Create();
		projectile.transform.position = transform.position;
	}
}
