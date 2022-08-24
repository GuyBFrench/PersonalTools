using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class IntData : ScriptableObject
{
    public int danger;

    public void IncreaseDanger(int killedEnemies)
    {
        danger += killedEnemies;
    }

    public void RemoveDanger(int pickupValue)
    {
        danger -= pickupValue;
    }
}
