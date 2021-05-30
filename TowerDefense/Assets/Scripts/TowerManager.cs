using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerManager : MonoBehaviour
{   
    private Transform target;

    [Header("Attributes")]
    public string nameTower = "Tower";
    public Sprite imgTower;
    public float price = 100f;
    public float attack = 1f;
    public float fireRate = 1f;  
    public float range = 15f;
    public string description;
    
    private float fireCountdown = 0f;

    [Header("Unity Setup Fields")]
    public string enemyTag = "Enemy";
    public GameObject bulletPrefab;
    public float turnSpeed = 10;
    public Transform partToRotate;
    public List<Transform> firePoint;
    
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

        if(nearesEnemy != null && shortesDistance <= range)
        {
            target = nearesEnemy.transform;
            
        }else
        {
            target = null;
        }

    }

    void Update()
    {
        if(fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = 1f/fireRate;
        }
        fireCountdown -= Time.deltaTime;
        TargetLockOn();
    }

    void Shoot()
    {
        if(target == null)
            return; 

        foreach (Transform firePoint in firePoint)
        {
            GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Bullet bullet = bulletGO.GetComponent<Bullet>();
            bullet.attack = attack;  
            if(bullet != null)
            {
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

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }


}
