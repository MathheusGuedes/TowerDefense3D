
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;
    private EnemyMove enemyStatus;
    public float speed = 70;
    public GameObject impactEffect;
    public void Seek(Transform _target)
    {
        target = _target;
        if(target != null)
        {
            enemyStatus = target.GetComponent<EnemyMove>();
        }
    }

    void Update()
    {
        if(target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if(dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }

    void HitTarget()
    {
        GameObject effectIns = Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectIns, 2f);
        enemyStatus.life --;
        Destroy(gameObject);

    }

    
}
