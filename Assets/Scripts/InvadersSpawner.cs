using UnityEngine;
using Zenject;

public class InvadersSpawner
{
	private const float Width = 15f;
	private const float MaxHeight = 4.5f;
	private const float RowHeight = 1f;
	private const float HorizontalOffset = 0.5f;
	private const int InRowCount = 10;
	private const int RowsCount = 3;

	private Invader.Factory _invadersFactory;
	private DataModel _dataModel;

	public InvadersSpawner(SignalBus signalBus, Invader.Factory invadersFactory, DataModel dataModel)
	{
		_invadersFactory = invadersFactory;
		_dataModel = dataModel;

		signalBus.Subscribe<RestartLevelSignal>(RespawnInvaders);
	}

	private void RespawnInvaders()
	{
		var height = MaxHeight;
		var widthStep = Width / InRowCount;
		var leftPos = -Width / 2;
		var count = 0;
		for (int i = 0; i < RowsCount; i++)
		{
			for (int j = 0; j < InRowCount; j++)
			{
				var pos = new Vector3(HorizontalOffset + leftPos + widthStep * j, height, 0);
				var invader = _invadersFactory.Create();
				invader.transform.position = pos;
				count++;
			}

			height -= RowHeight;
		}

		_dataModel.InvadersCount.Value = count;
	}
}
