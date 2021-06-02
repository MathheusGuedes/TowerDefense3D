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
    private PlayerStats player;
    private Node node;

    public void SetPlayerStats(PlayerStats stats)
    {
        player = stats;
    }

    public void SelectTowerToBuild(GameObject _slotShop)
    {
        ChangeColorTowerSelect(_slotShop);
        slotShop = _slotShop;
    }

    public GameObject GetTowerToBuild()
    {
        return towerToBuild;
    }

    public void SetNodeToBuild(Node _node)
    {   
        if(node != null)
            node.DiselectNode();

        node = _node;

        if(_node.tower != null)
        {
            SetTowerToUpgrade(_node.tower);
        }
        else
        {   
            towerToUpgrade = null;
            ToBuild();
        }
    }

    public Node GetNodeToBuild()
    {
        return node;
    }

    public PlayerStats GetPlayerStats()
    {
        return player;
    }
    
    public bool CanBuild()
    {   
        if(towerToBuild != null && node.tower == null)
        {
            TowerManager statsTower = towerToBuild.GetComponent<TowerManager>();
            if(player.GetGoldAmout() >= statsTower.price)
            {
                player.RemoveGold(statsTower.price);
                return true;
            }
            return false;
        }
        else
            return false;
    }

    public void AddPreviewTower(Node _node)
    {
        if(towerToBuild != null)
        {
            if(_node.tower == null)
            {
                _node.previewTower = Instantiate(towerToBuild, _node.transform.position + _node.positionOffSet, _node.transform.rotation);
            }
        }
    }

    public void RemovePreviewTower(Node _node)
    {
        if(_node.previewTower != null)
        {
            Destroy(_node.previewTower);
            _node.previewTower = null;
        }
    }

    public void ToBuild()
    {   
        if(CanBuild())
        {
            node.tower = Instantiate(towerToBuild, node.transform.position + node.positionOffSet, node.transform.rotation);
            GameObject efConst = Instantiate(towerToBuild.GetComponent<TowerManager>().constructionEffect, node.transform.position, towerToBuild.GetComponent<TowerManager>().constructionEffect.transform.rotation);
            towerToBuild = null;
            slotShop.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            Destroy(node.previewTower);
            Destroy(efConst, 2f);
        }
    }
    
    public GameObject GetTowerToUpgrade()
    {
        return towerToUpgrade;
    }
    
    public void SetTowerToUpgrade(GameObject tower)
    {
        towerToBuild = null;
        towerToUpgrade = tower;
    }

    void ChangeColorTowerSelect(GameObject _slotShop)
    {
        towerToUpgrade = null;
        
        if(_slotShop == null)
        {
            if(slotShop != null)
                slotShop.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
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
