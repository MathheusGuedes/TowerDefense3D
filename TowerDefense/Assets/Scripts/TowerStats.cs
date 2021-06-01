using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TowerStats
{
    public int level = 1;
    public float attack = 1f;
    public float fireRate = 1f;  
    public float range = 15f;

    [Header("Prices")]
    public float priceUpgrade = 150f;
    public float priceSell = 80;
}
