using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : PlayerHealth
{
    public void TakeDamage(float dmg )
    {
        health -= dmg;
        if (health > 0) return;
        
        GameManager._Instance.PlayerRootObject.GetComponent<PlayerBody>().Death();
    }
}
