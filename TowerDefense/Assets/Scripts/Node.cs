using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{   
    public Color houverColor;
    private Color startColor;
    private Renderer rend;

    public Vector3 positionOffSet;

    private GameObject tower;

    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = GetComponent<Renderer>().material.color;
    }

    void OnMouseDown()
    {
        if(tower != null)
        {
            print("Can't build there!");
            return;
        }
    
    GameObject towerToBuild = BuildManager.instance.GetTowerToBuild();
    tower = Instantiate(towerToBuild, transform.position + positionOffSet, transform.rotation);

    }

    void OnMouseEnter()
    {   
        rend.material.color = houverColor;
    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }
    
}
