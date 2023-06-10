using UnityEngine;
using Zenject;

public class AmmoSpawner
{
   private SignalBus _signalBus;
   private Ammo.Factory _factory;
   private WeaponsSettings _weaponsSettings;
   
   public AmmoSpawner(SignalBus signalBus,
      WeaponsSettings weaponsSettings,
      Ammo.Factory factory)
   {
      signalBus.Subscribe<InvaderKilledSignal>(TrySpawnAmmo);
      _weaponsSettings = weaponsSettings;
      _factory = factory;
   }

   private void TrySpawnAmmo(InvaderKilledSignal signal)
   {
      var id = _weaponsSettings.WeaponsData[Random.Range(0, _weaponsSettings.WeaponsData.Length)].Id;
      
      var ammo = _factory.Create(id);
      ammo.transform.position = signal.Position;
   }
}
