using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour
{   
    [Header("Objetos")]
    public ScriptableTower towerStatus;
    public GameObject eixoCanon;
    public Transform saidaDoTiro;
    public SphereCollider rangeAttack;
    
    public GameManager _gameManager;
    public GameObject target;
    bool waiting;


    void Start()
    {
        if(towerStatus != null)
        {
            rangeAttack.radius = towerStatus.towers.rangeAttackBase;
        }
        
    }

    void Update()
    {
        if(target != null)
        {
            eixoCanon.transform.LookAt(target.transform);
            StartCoroutine(Shooting(towerStatus.towers.attackSpeed));

        }
    }

    public IEnumerator Shooting(float timeAttack)
    {
        while(!waiting)
        {
            waiting = true;
            if(target != null)
            {
                GameObject bullet = Instantiate(towerStatus.towers.Tiro, saidaDoTiro.position, Quaternion.identity);
                Rigidbody rigB = bullet.GetComponent<Rigidbody>();
                bullet.transform.LookAt(target.transform);
                rigB.velocity = eixoCanon.transform.forward * 30;
                yield return new WaitForSeconds(towerStatus.towers.attackSpeed);
            }
            waiting = false;
        }

    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            target = other.gameObject;
        }        
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            target = null;
        }        
    }


}
