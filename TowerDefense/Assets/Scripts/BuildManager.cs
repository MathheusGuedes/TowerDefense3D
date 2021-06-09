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
    private GameObject slotShop;
    private GameObject player;

    public bool CanBuild { get {return towerToBuild != null;}}

    public void SetTowerToBuild(GameObject _slotShop)
    {
        ChangeColorTowerSelect(_slotShop);
        slotShop = _slotShop;
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



    void ChangeColorTowerSelect(GameObject _slotShop)
    {
        towerToUpgrade = null;
        
        if(_slotShop == null)
        {
            if(slotShop != null)
                slotShop.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            return;
        }
        else {
            towerToBuild = _slotShop.GetComponent<SlotShopTower>().tower;

            if(slotShop != null)
            {
                slotShop.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                _slotShop.GetComponent<Image>().color = new Color32(150, 180, 230, 255);
            }
            else{
                _slotShop.GetComponent<Image>().color = new Color32(150, 180, 230, 255);
            }
        }
    }
}
