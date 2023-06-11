using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

public class Bullet : Projectile
{
    protected override void CheckCollision(Collider2D other)
    {
        if (other.CompareTag(Constants.InvaderTag))
        {
            _signalBus.Fire(new InvaderKilledSignal(other.transform.position));
            
            Destroy(other.gameObject);
            Kill();
        }
    }
    
    public class Factory : ProjectileFactory<Bullet>
    {
        public Factory(DiContainer container, WeaponsSettings settings): base(container, settings) { }

        protected override  GameObject GetPrefab(string id)
        {
            return _settings.WeaponsData.FirstOrDefault(w=> w.Id == id).Bullet;
        }
    }
}

