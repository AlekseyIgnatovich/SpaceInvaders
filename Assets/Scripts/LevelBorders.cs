using UnityEngine;

public class LevelBorders 
{
	public float Width { get; private set; }
	public float Height { get; private set; }
	
	public LevelBorders()
	{
		var camera = GameObject.FindObjectOfType<Camera>(); //Todo inject camera

		Height = camera.orthographicSize;
		Width = Height * camera.aspect;
	}
}
