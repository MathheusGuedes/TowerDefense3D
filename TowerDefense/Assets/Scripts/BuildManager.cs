
using UnityEngine;

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
    
    public void SetTowerToBuild(GameObject tower)
    {
        towerToBuild = tower;
    }
    public GameObject GetTowerToBuild()
    {
        return towerToBuild;
    }
}
