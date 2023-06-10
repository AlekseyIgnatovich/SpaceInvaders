using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

public class Ammo : Projectile
{
	public string Id { get; private set; }
	
	public void Init(string id )
	{
		Id = id;
	}
	
    protected override void CheckCollision(Collider2D other)
    {
        if (other.CompareTag(Constants.PlayerTag))
        {
	        _signalBus.Fire(new AmmoCollectedSignal(Id));
	        
	        Destroy(gameObject);
        }
    }

    public class Factory : PlaceholderFactory<Ammo>
    {
	    readonly DiContainer _container;
	    readonly WeaponsSettings _settings;

	    public Factory(
		    DiContainer container,
		    WeaponsSettings settings)
	    {
		    _container = container;
		    _settings = settings;
	    }

	    public Ammo Create(string id)
	    {
		    var  ammo = _container.InstantiatePrefabForComponent<Ammo>(GetPrefab(id));
		    ammo.Init(id);// Todo: remove init
		    return ammo;
	    }

	    GameObject GetPrefab(string id)
	    {
		    return _settings.WeaponsData.FirstOrDefault(w=> w.Id == id).Ammo;
	    }
    }
}
