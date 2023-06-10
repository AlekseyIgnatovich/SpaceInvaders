using Cysharp.Threading.Tasks;
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
            UniTask.Run(RestartLevelDelayed);
        }
    }

    async void RestartLevelDelayed()
    {
        await UniTask.Delay(1000);
        _signalBus.Fire<RestartLevelSignal>();
    }

    void RestartLevel()
    {
        _signalBus.Fire<RestartLevelSignal>();
    }
}
