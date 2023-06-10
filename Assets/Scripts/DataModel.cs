using Zenject;

public class DataModel
{
    public string WeaponId = "Weapon_0";
    public NotifableProperty<int> Score = new NotifableProperty<int>();
    public NotifableProperty<int> InvadersCount = new NotifableProperty<int>();

    [Inject]
    public void Construct(SignalBus signalBus)
    {
        signalBus.Subscribe<AmmoCollectedSignal>((s) => WeaponId = s.WeaponId);
        signalBus.Subscribe<InvaderKilledSignal>(() =>
        {
            Score.Value++;
            InvadersCount.Value--;
        });
    }
}
