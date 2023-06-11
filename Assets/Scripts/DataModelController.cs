using Zenject;

public class DataModelController
{
    [Inject]
    public void Construct(SignalBus signalBus, DataModel dataModel)
    {
        signalBus.Subscribe<RestartLevelSignal>(() => dataModel.Score.Value = 0);
        signalBus.Subscribe<AmmoCollectedSignal>((s) => dataModel.WeaponId = s.WeaponId);
        signalBus.Subscribe<InvaderKilledSignal>(() =>
        {
            dataModel.Score.Value++;
            dataModel.InvadersCount.Value--;
        });
    }
}
