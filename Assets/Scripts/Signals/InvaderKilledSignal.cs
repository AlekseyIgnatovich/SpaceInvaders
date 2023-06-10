using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct InvaderKilledSignal 
{
	public Vector3 Position;

	public InvaderKilledSignal(Vector3 position)
	{
		Position = position;
	}
}
