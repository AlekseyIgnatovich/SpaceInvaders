using Zenject;

public class DataModel
{
    public string WeaponId = "Weapon_0";
    public NotifableProperty<int> Score = new NotifableProperty<int>();
    public NotifableProperty<int> InvadersCount = new NotifableProperty<int>();
}
