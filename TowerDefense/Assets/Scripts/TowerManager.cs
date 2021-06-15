using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerManager : MonoBehaviour
{   
    enum rarity {normal, rare, special, ultra}

    [Header("TypeTower")]
    [SerializeField]
    rarity rarityTower;
    public Color32 rarityColor;
    public string nameTower;
    public Sprite imgTower;
    public string description;
    public Color32 bulletColor;
    public int price = 100;

    [Header("Attributes")]
    public int currentLevel = 0;
    public TowerStats[] stats;
    [HideInInspector]
    public int nextLevel = 1;

    [Header("Unity Setup Fields")]
    public string enemyTag = "Enemy";
    public GameObject bulletPrefab;
    public float turnSpeed = 10;
    public Transform partToRotate;
    public List<Transform> firePoint;
    private float fireCountdown = 0f;
    private Transform target;
    public Image imgRange;
    public GameObject constructionEffect;
    public GameObject lightEffect;

    bool shoot = false;

    void OnValidate()
    {
        ChangeRarity();
    }

    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.2f);
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
        imgRange.rectTransform.sizeDelta = new Vector2(stats[currentLevel].range*4, stats[currentLevel].range*4);
        if(fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = 1f/stats[currentLevel].fireRate;
        }
        fireCountdown -= Time.deltaTime;
        TargetLockOn();

        imgRange.transform.eulerAngles += new Vector3(0, 0, imgRange.transform.rotation.z+1 * 90 * Time.deltaTime);
    }

    void Shoot()
    {
        if(shoot)
        {
            if(target == null)
            return; 
            foreach (Transform firePoint in firePoint)
            {
                GameObject bulletGO = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
                Bullet bullet = bulletGO.GetComponent<Bullet>();
                bullet.bulletColor = bulletColor;
                bullet.attack = stats[currentLevel].attack;  
                if(bullet != null)
                    bullet.Seek(target);       
            }
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

    void ChangeRarity()
    {
        switch (rarityTower)
        {
            case rarity.normal:
                rarityColor = new Color32(0,0,0,255);
            break;
            case rarity.rare:
                rarityColor = new Color32(70,255,45,255);
            break;
            case rarity.special:
                rarityColor = new Color32(255,190,0,255);
            break;
            case rarity.ultra:
                rarityColor = new Color32(150,0,220,255);
            break;
        }
    }

    public void ActiveRange()
    {
        imgRange.enabled = true;
        lightEffect.SetActive(true);
    }

    public void DesactiveRange()
    {
         imgRange.enabled = false;
         lightEffect.SetActive(false);
    }

    public void ActiveShoot()
    {
        shoot = true;
    }

    public void DesactiveShoot()
    {
        shoot = false;
    }
}
