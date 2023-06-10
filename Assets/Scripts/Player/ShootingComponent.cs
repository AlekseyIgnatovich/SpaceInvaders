using UnityEngine;
using Zenject;

public class ShootingComponent : MonoBehaviour
{
	private Bullet.Factory _projectileFactory;
	private DataModel _dataModel;
	
	[Inject]
	public void Init(Bullet.Factory projectileFactory, DataModel dataModel)
	{
		_projectileFactory = projectileFactory;
		_dataModel = dataModel;
	}
	
	public void Shoot()
	{
		var projectile = _projectileFactory.Create(_dataModel.WeaponId);
		projectile.transform.position = transform.position;
	}
}
