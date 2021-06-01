using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{   
    public Color houverColor;
    private Color startColor;
    private Renderer rend;

    public Vector3 positionOffSet;

    public GameObject tower;

    BuildManager buildManager;

    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = GetComponent<Renderer>().material.color;
        buildManager = BuildManager.instance;
    }

    void OnMouseDown()
    {
        if(EventSystem.current.IsPointerOverGameObject())
            return;

        if(tower == null)
        {
            if(buildManager.GetTowerToBuild() != null)
            {
                GameObject towerToBuild = BuildManager.instance.GetTowerToBuild();
                tower = Instantiate(towerToBuild, transform.position + positionOffSet, transform.rotation);
                buildManager.SetTowerToBuild(null);
                buildManager.SetSelectTowerToBuild(null);
            }
            buildManager.SetTowerToUpgrade(null);
        }
        else
        {   
            buildManager.SetTowerToUpgrade(tower);
        }
    }


    void OnMouseEnter()
    {   
        if(EventSystem.current.IsPointerOverGameObject())
            return;
        rend.material.color = houverColor;
    }

    void OnMouseExit()
    {
        
        rend.material.color = startColor;
    }
    
}
