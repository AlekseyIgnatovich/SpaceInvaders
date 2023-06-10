using System.Threading.Tasks;
using UnityEngine;
using Zenject;

public class LevelController
{
    private SignalBus _signalBus;
    private DataModel _dataModel;
        
    [Inject]
    void Construct(SignalBus signalBus, DataModel dataModel)
    {
        _signalBus = signalBus;
        _dataModel = dataModel;

        _dataModel.InvadersCount.OnChanged += OnInvadersCountChanged;

        RestartLevel();
    }

    private void OnInvadersCountChanged(int count)
    {
        if (count == 0)
        {
            RestartLevel();
        }
    }

    void RestartLevel()
    {
        _signalBus.Fire<RestartLevelSignal>();
    }
}
