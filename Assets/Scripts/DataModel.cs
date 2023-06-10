using Zenject;

public class DataModel
{
    public string WeaponId = "Weapon_0";
    public int Score;

    [Inject]
    public void Construct(SignalBus signalBus)
    {
        signalBus.Subscribe<AmmoCollectedSignal>((s) => WeaponId = s.WeaponId);
        signalBus.Subscribe<InvaderKilledSignal>(() => Score++);
    }
}
