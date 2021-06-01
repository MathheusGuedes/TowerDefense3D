using System;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour
{   
    enum rarity {normal, rare, special, ultra}

    [Header("TypeTower")]
    [SerializeField]
    rarity rarityTower;
    Color32 rarityColor;
    public string nameTower;
    public Sprite imgTower;
    public string description;
    public float price = 100f;

    [Header("Attributes")]
    public Stats[] stats;
    public int currentLevel = 0;
    public int nextLevel = 1;


    [Header("Unity Setup Fields")]
    public string enemyTag = "Enemy";
    public GameObject bulletPrefab;
    public float turnSpeed = 10;
    public Transform partToRotate;
    public List<Transform> firePoint;
    private float fireCountdown = 0f;
    private Transform target;

    void Start()
    {
        

        InvokeRepeating("UpdateTarget", 0f, 1f);
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortesDistance = Mathf.Infinity;
        GameObject nearesEnemy = null;
        
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if(distanceToEnemy <= shortesDistance)
            {
                shortesDistance = distanceToEnemy;
                nearesEnemy = enemy;
            }
        }

        if(nearesEnemy != null && shortesDistance <= stats[currentLevel].range)
            target = nearesEnemy.transform;
        else
            target = null;

    }

    void Update()
    {
        if(fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = 1f/stats[currentLevel].fireRate;
        }
        fireCountdown -= Time.deltaTime;
        TargetLockOn();
        ChangeRarity();
    }

    void Shoot()
    {
        if(target == null)
            return; 

        foreach (Transform firePoint in firePoint)
        {
            GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Bullet bullet = bulletGO.GetComponent<Bullet>();
            bullet.attack = stats[currentLevel].attack;  

            if(bullet != null)
                bullet.Seek(target);       
        }
    }

    void TargetLockOn()
    {
        if(target == null)
            return;

        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, stats[currentLevel].range);
    }

    void ChangeRarity()
    {
        switch (rarityTower)
        {
            case rarity.normal:
                rarityColor = Color.black;
            break;
            case rarity.rare:
                rarityColor = Color.green;
            break;
            case rarity.special:
                rarityColor = Color.yellow;
            break;
            case rarity.ultra:
                rarityColor = Color.red;
            break;
        }
    }

    public void LevelUp()
    {
        if(currentLevel < stats.Length)
            currentLevel ++;
        if(nextLevel < stats.Length-1)
            nextLevel ++;
    }

}


[System.Serializable]
public class Stats
{
    public int level = 1;
    public float attack = 1f;
    public float fireRate = 1f;  
    public float range = 15f;

    [Header("Prices")]
    public float priceUpgrade = 150f;
    public float priceSell = 80;

}