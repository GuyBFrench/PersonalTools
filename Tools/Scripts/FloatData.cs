using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class FloatData : ScriptableObject
{
    public float playerHealth;


    public void UpdateHealth(float damage)
    {
        playerHealth -= damage;
    }

    public void ReturnHealth(float heal)
    {
        playerHealth += heal;
    }

}
