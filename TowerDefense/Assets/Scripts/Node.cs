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

    //Controll select
    static bool itsSelect = false;

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

        if(!itsSelect && tower != null)
            SelectNode();

        if(buildManager.GetTowerToBuild() == null)
            return;

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
        itsSelect = true;
        if(tower != null)
        {
            tower.GetComponent<TowerManager>().ActiveRange();
        }
        rend.material.color = houverColor;
    }
    
    public void DiselectNode()
    {   
        itsSelect = false;
        if(tower != null)
        {
            tower.GetComponent<TowerManager>().DesactiveRange();
        }
        rend.material.color = startColor;
    }
    
}
