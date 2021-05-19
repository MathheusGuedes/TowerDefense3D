
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float speed = 10f;

    private Transform target;
    private int wavepointIndex = 0;

    public float distance;

    void Start()
    {
        target = Waypoints.points[0];
    }

    void Update()
    {
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
            Destroy(gameObject);
        }
        else{
            wavepointIndex ++;
            target = Waypoints.points[wavepointIndex];
        }
        
    }

}
