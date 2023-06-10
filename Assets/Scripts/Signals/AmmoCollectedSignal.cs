using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct AmmoCollectedSignal
{
    public string WeaponId;

    public AmmoCollectedSignal(string weaponId)
    {
        WeaponId = weaponId;
    }
}
