using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int maxHP = 5;
    int currentHP = 0;

    void Start()
    {
        currentHP = maxHP;
    }

    //被粒子系統碰撞的時候
    void OnParticleCollision(GameObject other) 
    {
        currentHP--;
        if(currentHP <=0)
        {
            Destroy(gameObject); //摧毀自己
        }
    }
}
