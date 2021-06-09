using UnityEngine;

public class Waypoints : MonoBehaviour
{
    public Transform[] points;

    void Start()
    {
        points = new Transform[transform.childCount];
        for (int i = 0; i < points.Length; i++)
        {
           points[i] = transform.GetChild(i); 
        }
    }
    
}
