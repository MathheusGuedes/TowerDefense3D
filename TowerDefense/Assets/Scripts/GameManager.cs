using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static float timeSpeed = 1f;
    public Text txtTimeSpeed;

    void Update()
    {
        Time.timeScale = timeSpeed;
        txtTimeSpeed.text = "Speed: " + timeSpeed + "x";
    }

    public void ChangeTimeSpeed()
    {
        if(timeSpeed == 1)
        {
            timeSpeed = 2;
        }
        else if(timeSpeed == 2)
        {
            timeSpeed = 4;
        }
        else{
            timeSpeed = 1;
        }
    }
}
