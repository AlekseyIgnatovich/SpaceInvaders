using UnityEngine;
using Zenject;

public class Invader : MonoBehaviour
{
	public class Factory : PlaceholderFactory<Invader>
	{
	}
}
