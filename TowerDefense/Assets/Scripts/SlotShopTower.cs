using UnityEngine;
using UnityEngine.UI;

public class SlotShopTower : MonoBehaviour
{
    
    BuildManager buildManager;    
    public GameObject tower;
    public TowerManager statsTower;
    public Image imgTower;
    public Text txtName;
    public Text txtAttack;
    public Text txtRange;
    public Text txtSpeed;
    public Text txtValue;
    public Text txtDescription;

    public Button btnBuy;

    void Start()
    {
        buildManager = BuildManager.instance;
        statsTower = tower.GetComponent<TowerManager>();
        txtName.text = statsTower.nameTower.ToString();
        txtAttack.text = "Atk: " + (statsTower.stats[statsTower.currentLevel].attack * statsTower.firePoint.Count);
        txtRange.text = "Rng: " + statsTower.stats[statsTower.currentLevel].range.ToString();
        txtSpeed.text = "Spd: " + statsTower.stats[statsTower.currentLevel].fireRate.ToString();
        txtValue.text = statsTower.price.ToString() + "$";
        txtDescription.text = statsTower.description.ToString();
        imgTower.sprite = statsTower.imgTower;
        btnBuy.onClick.AddListener(() => BuyTheTower(tower));
    }

    public void BuyTheTower(GameObject tower)
    {
        buildManager.SetSelectTowerToBuild(this.gameObject);
        buildManager.SetTowerToBuild(tower);
    }

}
