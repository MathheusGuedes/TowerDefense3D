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
        txtAttack.text = "Atk: " + (statsTower.attack * statsTower.firePoint.Count);
        txtRange.text = "Rng: " + statsTower.range.ToString();
        txtSpeed.text = "Spd: " + statsTower.fireRate.ToString();
        txtValue.text = statsTower.price.ToString() + "$";
        txtDescription.text = statsTower.description.ToString();
        imgTower.sprite = statsTower.imgTower;
        btnBuy.onClick.AddListener(() => BuyTheTower(tower));

    }

    void Update()
    {
        
    }

    public void BuyTheTower(GameObject tower)
    {
        buildManager.SetTowerToBuild(tower);
    }

}
