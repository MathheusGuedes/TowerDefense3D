
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("MOre than one BuildManager in scene!");
        }
        instance = this;
    }
    public GameObject standardTowerPrefab;
    private GameObject towerToBuild;

    void Start()
    {
        towerToBuild = standardTowerPrefab;
    }
    
    public GameObject GetTowerToBuild()
    {
        return towerToBuild;
    }
}
