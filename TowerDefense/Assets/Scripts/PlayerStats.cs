using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public int gold;
    public float life;
    public int level;
    public float exp;
    public float maxExp;


    public Text txtLife;
    public Text txtGold;

    BuildManager buildManager;

    void Start()
    {   
        buildManager = BuildManager.instance;
        buildManager.SetPlayerStats(this);
    }

    public int GetGoldAmout()
    {
        return gold;
    }

    public void AddGold(int _gold)
    {
        gold += _gold;
    }

    public void RemoveGold(int _gold)
    {   
        gold -= _gold;
        if(gold <= 0)
            gold = 0;
    }

    public float GetLifeAmount()
    {
        return life;
    }

    public void RemoveLife(float damage)
    {   
        if(GetItsLive())
            life -= damage;
    }

    public void AddLife(int heal)
    {
        life += heal;
    }

    public bool GetItsLive()
    {
        if(life <= 0)
            return false;
        else
            return true;
    }
    
    void Update()
    {
        txtGold.text = "Gold: $" + gold;
        txtLife.text = "Life: " + life;
    }
}
