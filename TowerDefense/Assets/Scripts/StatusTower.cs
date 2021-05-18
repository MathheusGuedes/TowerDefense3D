using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StatusTower 
{
    public string nameTower;

    public float rangeAttackBase;

    [HideInInspector]
    public float rangeAttack;

    public float attackSpeed;
    public float damage;

    public GameObject Tiro;
}
