using Zenject;

public class GameInstaller  : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<PlayerSpawner>().AsSingle().NonLazy();;
        Container.BindInterfacesAndSelfTo<InvadersSpawner>().AsSingle().NonLazy();;
    }
}
