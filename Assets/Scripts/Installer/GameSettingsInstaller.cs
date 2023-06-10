using System;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "GameInstaller", menuName = "Installers/GameInstaller")]
public class GameSettingsInstaller : ScriptableObjectInstaller<GameSettingsInstaller>
{
    public Settings GameSettings;
    
    public override void InstallBindings()
    {
        Container.BindFactory<Player, Player.Factory>().FromComponentInNewPrefab(GameSettings.PlayerPrefab).AsSingle();
        Container.BindFactory<Invader, Invader.Factory>().FromComponentInNewPrefab(GameSettings.InvaderPrefab).AsSingle();
        Container.BindFactory<Projectile, Projectile.Factory>().FromComponentInNewPrefab(GameSettings.ProjectilePrefab).AsSingle();
    }
    
    [Serializable]
    public class Settings
    {
        public Player PlayerPrefab;
        public Invader InvaderPrefab;
        public Projectile ProjectilePrefab;
    }
}