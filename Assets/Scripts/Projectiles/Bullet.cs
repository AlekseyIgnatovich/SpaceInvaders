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
            Destroy(gameObject);
        }
    }
    
    public class Factory : PlaceholderFactory<Bullet>//ToDo: copypaste
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

        public Bullet Create(string id)
        {
            return _container.InstantiatePrefabForComponent<Bullet>(GetPrefab(id));
        }

        GameObject GetPrefab(string id)
        {
            return _settings.WeaponsData.FirstOrDefault(w=> w.Id == id).Bullet;
        }
    }
}
