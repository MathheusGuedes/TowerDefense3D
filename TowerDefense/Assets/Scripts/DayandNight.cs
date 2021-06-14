
using UnityEngine;
using UnityEngine.UI;

public class DayandNight : MonoBehaviour
{       
    [Header("Minutes/Hours/Days")]
    public float timeSpeed;
    private float minute;
    private float hour = 6f;
    private float day;
    private float hourAndMinute;
    public static bool itsNigth;

    [Header("Components")]    
    public Text hourText;
    public Light sun;
    public Light moon;

    Vector3 rotSun;
    Vector3 rotMoon;


    void Start()
    {
        rotSun = sun.transform.eulerAngles;
        rotMoon = moon.transform.eulerAngles;
    }

    void Update()
    {
        HourAndMinute();
    }

    void HourAndMinute()
    {
        minute += timeSpeed * Time.deltaTime * timeSpeed;
        if (minute >= 60)
        {
            minute = 0f;
            hour++;
        }
        if (hour >= 24)
        {
            day++;
            hour = 0;
        }
        hourAndMinute = hour + (((minute * 100) / 60)/100);
        sun.transform.eulerAngles = new Vector3(((hourAndMinute * 360f) / 24f) - 90f, 0, 0);
        moon.transform.eulerAngles = new Vector3(((hourAndMinute * 360f) / 24f) + 90f, 0, 0);

        if(sun.transform.eulerAngles.x > 180) itsNigth = true;
        else itsNigth = false;

        string dayAndHour = string.Format("Day {0:0}    {01:00}hrs", day, hour);
        hourText.text = dayAndHour.ToString();
    }

}
