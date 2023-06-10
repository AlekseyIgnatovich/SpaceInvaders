using System;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "GameInstaller", menuName = "Installers/GameInstaller")]
public class GameSettingsInstaller : ScriptableObjectInstaller<GameSettingsInstaller>
{
    public GameSettings Settings;

    public override void InstallBindings()
    {
        Container.BindInstance(Settings.weaponsSettings);

        Container.BindFactory<Player, Player.Factory>()
            .FromComponentInNewPrefab(Settings.PlayerPrefab).AsSingle();
        Container.BindFactory<Invader, Invader.Factory>()
            .FromComponentInNewPrefab(Settings.InvaderPrefab).AsSingle();
        
        Container.BindFactory<Bullet, Bullet.Factory>().AsSingle();
        Container.BindFactory<Ammo, Ammo.Factory>().AsSingle();
    }
}

[Serializable]
public class GameSettings
{
    public Player PlayerPrefab;
    public Invader InvaderPrefab;

    public WeaponsSettings weaponsSettings;
}

[Serializable]
public class WeaponsSettings
{
    public WeaponData[] WeaponsData;
}

[Serializable]
public struct WeaponData
{
    public string Id;
    public GameObject Ammo;
    public GameObject Bullet;
}