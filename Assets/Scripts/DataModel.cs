using Zenject;

public class DataModel
{
    public string WeaponId = Constants.DefaultWeaponId;
    public NotifableProperty<int> Score = new NotifableProperty<int>();
    public NotifableProperty<int> InvadersCount = new NotifableProperty<int>();
}
