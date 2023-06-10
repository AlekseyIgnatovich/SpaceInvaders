using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
	public override void InstallBindings()
	{
		SignalBusInstaller.Install(Container);

		Container.DeclareSignal<AmmoCollectedSignal>();
		Container.DeclareSignal<InvaderKilledSignal>();
		Container.DeclareSignal<RestartLevelSignal>();

		Container.BindInterfacesAndSelfTo<PlayerSpawner>().AsSingle().NonLazy();
		Container.BindInterfacesAndSelfTo<InvadersSpawner>().AsSingle().NonLazy();
		Container.BindInterfacesAndSelfTo<AmmoSpawner>().AsSingle().NonLazy();
		Container.BindInterfacesAndSelfTo<DataModel>().AsSingle();
		Container.BindInterfacesAndSelfTo<LevelController>().AsSingle().NonLazy();
	}
}
