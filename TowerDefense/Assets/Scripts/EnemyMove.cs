using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float life = 2;
    public float speedBase = 10f;
    public float speed = 10f;
    
    public int maxGold;
    public int minGold;

    public Transform target;
    private int wavepointIndex = 0;

    public float distance;

    public GameObject effectDeath;

    BuildManager buildManager;

    void Start()
    {   
        buildManager = BuildManager.instance;
        target = GameObject.FindGameObjectWithTag("WayPoints").GetComponent<Waypoints>().points[0];
    }

    void Update()
    {
        OnDie();
        
        if(DayandNight.itsNigth)
        {
            speed = speedBase * 2f;
        }
        else{
            speed = speedBase;
        }

        distance = Vector3.Distance(transform.position, target.position);

        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime);
        
        if(Vector3.Distance(transform.position, target.position) <= 0.3f)
        {
            GetNextWaypoint();
        }
    }

    void GetNextWaypoint()
    {
        if(wavepointIndex  >= Waypoints.points.Length - 1)
        {
            LastWaypoint();
        }
        else{
            wavepointIndex ++;
            target = Waypoints.points[wavepointIndex];
        }
    }

    void LastWaypoint()
    {   
        buildManager.GetPlayerStats().RemoveLife(life);
        Destroy(gameObject);
    }

    void OnDie()
    {
        if(life <= 0)
        {   
            int dropGold = Random.Range(minGold, maxGold);
            buildManager.GetPlayerStats().AddGold(dropGold);
            GameObject effectIns = Instantiate(effectDeath, transform.position, transform.rotation);
            Destroy(effectIns, 2f);
            Destroy(gameObject);
        }
    }

}
