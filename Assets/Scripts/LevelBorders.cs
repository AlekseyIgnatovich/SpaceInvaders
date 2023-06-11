using UnityEngine;
using Zenject;

public class LevelBorders
{
	public float Width { get; private set; }
	public float Height { get; private set; }

	public LevelBorders([Inject(Id = Constants.MainCameraId)] Camera camera)
	{
		Height = camera.orthographicSize;
		Width = Height * camera.aspect;
	}
}
