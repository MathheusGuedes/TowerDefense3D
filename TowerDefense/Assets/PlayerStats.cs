using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int money;
    public int life;

    void Update()
    {
        if(life <= 0)
        {
            print("Perdeu");
        }
    }
}
