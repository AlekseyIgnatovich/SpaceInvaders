using UnityEngine;
using Zenject;

public class InvadersSpawner
{
	private const float RowHeight = 1f;
	private const int RowsCount = 3;
	private const float WidthStep = 1.3f;

	private Invader.Factory _invadersFactory;
	private DataModel _dataModel;
	private LevelBorders _levelBorders;

	public InvadersSpawner(SignalBus signalBus,
		Invader.Factory invadersFactory,
		DataModel dataModel,
		LevelBorders levelBorders)
	{
		_invadersFactory = invadersFactory;
		_dataModel = dataModel;
		_levelBorders = levelBorders;

		signalBus.Subscribe<RestartLevelSignal>(RespawnInvaders);
	}

	private void RespawnInvaders()
	{
		var borderOffset = WidthStep / 2;
		var height = _levelBorders.Height - borderOffset;
		int inRowCount = (int)(2 * _levelBorders.Width / WidthStep);
		var leftPos = -WidthStep * inRowCount / 2;
		for (int i = 0; i < RowsCount; i++)
		{
			for (int j = 0; j < inRowCount; j++)
			{
				var pos = new Vector3(borderOffset + leftPos + WidthStep * j, height, 0);
				var invader = _invadersFactory.Create();
				invader.transform.position = pos;
			}

			height -= RowHeight;
		}

		_dataModel.InvadersCount.Value = RowsCount * inRowCount;
	}
}
