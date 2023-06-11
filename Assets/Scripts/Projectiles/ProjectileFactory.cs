using UnityEngine;
using Zenject;

public abstract class ProjectileFactory<T> : PlaceholderFactory<string,T>
{
    protected readonly WeaponsSettings _settings;

    private readonly DiContainer _container;

    public ProjectileFactory(
        DiContainer container,
        WeaponsSettings settings)
    {
        _container = container;
        _settings = settings;
    }

    public override T Create(string id)
    {
        var projectile = _container.InstantiatePrefabForComponent<T>(GetPrefab(id));
        OnCreated(id, projectile);
        return projectile;
    }

    protected virtual void OnCreated(string id, T projectile) { }

    protected abstract GameObject GetPrefab(string id);
}
