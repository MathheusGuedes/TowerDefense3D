using UnityEngine;
using UnityEngine.UI;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("More than one BuildManager in scene!");
        }
        instance = this;
    }

    private GameObject towerToBuild;
    private GameObject towerToUpgrade;
    public GameObject towerSelectedToBuild;

    public void SetTowerToBuild(GameObject tower)
    {
        towerToUpgrade = null;
        towerToBuild = tower;
    }
    public GameObject GetTowerToBuild()
    {
        return towerToBuild;
    }

    public void SetTowerToUpgrade(GameObject tower)
    {
        towerToBuild = null;
        towerToUpgrade = tower;
    }
    
    public GameObject GetTowerToUpgrade()
    {
        return towerToUpgrade;
    }

    public GameObject GetSelectTowerToBuild()
    {
        return towerSelectedToBuild;
    }

    public void SetSelectTowerToBuild(GameObject _tower)
    {
        if(_tower == null)
        {
            if(towerSelectedToBuild != null)
                towerSelectedToBuild.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        }
        else{
            if(towerSelectedToBuild != null)
                towerSelectedToBuild.GetComponent<Image>().color = new Color32(255, 255, 255, 255);

            _tower.GetComponent<Image>().color = new Color32(150, 180, 230, 255);
        }
        towerSelectedToBuild = _tower;
    }
}
