using UnityEngine;
using Zenject;

public class PlayerSpawner
{
	private Player.Factory _playerFactory;
	private Player _player;
	private Vector3 _startPos;

	public PlayerSpawner(SignalBus signalBus, Player.Factory playerFactory)
	{
		_playerFactory = playerFactory;
		
		signalBus.Subscribe<RestartLevelSignal>(RespawnPlayer);
	}

	void RespawnPlayer()
	{
		if (_player == null)
		{
			_player = _playerFactory.Create();
			_startPos = _player.transform.position;
		}
		else
		{
			_player.transform.position = _startPos;
		}
	}
}
