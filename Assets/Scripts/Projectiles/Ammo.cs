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
	        
	        Kill();
        }
    }

    public class Factory : ProjectileFactory<Ammo>
    {
	    public Factory(DiContainer container, WeaponsSettings settings) : base(container, settings) { }
	    
	    protected override void OnCreated(string id, Ammo projectile)
	    {
		    projectile.Init(id);
	    }

	    protected override GameObject GetPrefab(string id)
	    {
		    return _settings.WeaponsData.FirstOrDefault(w => w.Id == id).Ammo;
	    }
    }
}
