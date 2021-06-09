using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float life = 2;
    public float speedBase = 10f;
    public float speed = 10f;

    public Transform target;
    private int wavepointIndex = 0;

    public float distance;

    public GameObject effectDeath;

    void Start()
<<<<<<< HEAD
    {   
        buildManager = BuildManager.instance;
        target = GameObject.FindGameObjectWithTag("Waypoints").GetComponent<Waypoints>().points[0];
=======
    {
        target = Waypoints.points[0];
>>>>>>> parent of 9985b87 (GoldSystem / LifeSystem / NewParticles / NewSpriteToRangeTower)
    }

    void Update()
    {
        if(life <= 0)
        {
            GameObject effectIns = Instantiate(effectDeath, transform.position, transform.rotation);
            Destroy(effectIns, 2f);
            Destroy(gameObject);
        }
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
        if(wavepointIndex  >= GameObject.FindGameObjectWithTag("Waypoints").GetComponent<Waypoints>().points.Length - 1)
        {
            Destroy(gameObject);
        }
        else{
            wavepointIndex ++;
            target = GameObject.FindGameObjectWithTag("Waypoints").GetComponent<Waypoints>().points[wavepointIndex];
        }
    }

}
