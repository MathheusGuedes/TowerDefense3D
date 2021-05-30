using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float timeSpeed = 1;
    public Text txtTimeSpeed;
    
    void Start()
    {
        
    }

    
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
