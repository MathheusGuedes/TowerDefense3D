
using UnityEngine;

public class DayandNight : MonoBehaviour
{
    public Light sun;
    public Light moon;

    public float timeSpeed;
    Vector3 rotSun;
    Vector3 rotMoon;

    public static bool itsNigth;

    void Start()
    {
        rotSun = sun.transform.eulerAngles;
        rotMoon = moon.transform.eulerAngles;
    }

    void Update()
    {
        if(sun.transform.eulerAngles.x > 180) itsNigth = true;
        else itsNigth = false;

        rotSun.x += timeSpeed * Time.deltaTime;
        rotMoon.x -= timeSpeed * Time.deltaTime;

        sun.transform.eulerAngles = rotSun;
        moon.transform.eulerAngles = rotMoon;
    }



}
