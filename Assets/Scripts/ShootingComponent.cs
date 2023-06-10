using UnityEngine;

public class ShootingComponent : MonoBehaviour
{
	[SerializeField] private GameObject _projectilePrefab;

	public void Shoot()
	{
		Instantiate(_projectilePrefab, transform.position, Quaternion.identity);
	}
}
