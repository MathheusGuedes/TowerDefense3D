using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;
    private EnemyMove enemyStatus;
    public float speed = 70;
    public float attack;
    public GameObject impactEffect;
    public Color32 bulletColor;

    void Start()
    {
        this.GetComponent<Renderer>().material.SetColor("_Color", bulletColor);
    }
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
        effectIns.GetComponent<Renderer>().material.SetColor("_Color", bulletColor);
        Destroy(effectIns, 2f);
        enemyStatus.life -= attack;
        Destroy(gameObject);
    }

    
}
