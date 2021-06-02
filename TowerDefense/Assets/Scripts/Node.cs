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
    public GameObject previewTower;

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

        buildManager.SetNodeToBuild(this);

        if(tower != null)
        {
            
            SelectNode();                      
        }
    }

    void OnMouseEnter()
    {  
        if(EventSystem.current.IsPointerOverGameObject())
            return;

        if(tower != null)
            SelectNode();

        if(buildManager.GetTowerToBuild() == null)
            return;

        SelectNode();
        buildManager.AddPreviewTower(this);
    }

    void OnMouseExit()
    {
        if(EventSystem.current.IsPointerOverGameObject())
            return;

        if(buildManager.GetTowerToUpgrade() != null)
            return;

        DiselectNode();
        buildManager.RemovePreviewTower(this);
    }

    public void SelectNode()
    {   
        if(tower != null)
        {
            tower.GetComponent<TowerManager>().ActiveRange();
        }
        rend.material.color = houverColor;
    }
    
    public void DiselectNode()
    {   
        if(tower != null)
        {
            tower.GetComponent<TowerManager>().DesactiveRange();
        }
        rend.material.color = startColor;
    }
    
}
