using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Vector3Data : ScriptableObject
{
    public Vector3 attack;

    public void AttackFromAbove(Vector3 playerPos)
    {   
        playerPos.y += 10;
        attack = playerPos;
    }

    public void TeleportToPlayer(Vector3 playerPos)
    {
        
        attack = playerPos;
    }

}
