using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeUI : MonoBehaviour
{
    TowerManager towerToUpgrade;
    BuildManager buildManager;

    [Header("Header")]
    public Image imgTower;
    public Image rarityTower;
    public Text txtName;
    public Text description;

    [Header("Current Stats")]
    public Text txtLevel;
    public Text txtAttack;
    public Text txtRange;
    public Text txtSpeed;

    [Header("Next Stats")]
    public Text txtNextLevel;
    public Text txtNextAttack;
    public Text txtNextRange;
    public Text txtNextSpeed;
    public GameObject pnlNextStats;
    public GameObject pnlMaxStats;

    [Header("Button")]
    public Text txtSell;
    public Text txtUpgrade;
    public Button btnSell;
    public GameObject btnUpgrade;

    void Start()
    {
        buildManager = BuildManager.instance;
        btnUpgrade.GetComponent<Button>().onClick.AddListener(() => towerToUpgrade.LevelUp());
    }


    void Update()
    {
        if(buildManager.GetTowerToUpgrade() != null)
        {   
            towerToUpgrade = buildManager.GetTowerToUpgrade().GetComponent<TowerManager>();
            rarityTower.color = towerToUpgrade.rarityColor;
            imgTower.sprite = towerToUpgrade.imgTower;
            txtName.text = towerToUpgrade.nameTower;
            description.text = towerToUpgrade.description;
            txtLevel.text = "Level: " + towerToUpgrade.stats[towerToUpgrade.currentLevel].level.ToString();
            txtAttack.text = "Attack: " + towerToUpgrade.stats[towerToUpgrade.currentLevel].attack * towerToUpgrade.firePoint.Count;
            txtRange.text = "Range: " + towerToUpgrade.stats[towerToUpgrade.currentLevel].range.ToString();
            txtSpeed.text = "Speed: " + towerToUpgrade.stats[towerToUpgrade.currentLevel].fireRate.ToString();
            txtSell.text = "Sell: $" + towerToUpgrade.stats[towerToUpgrade.currentLevel].priceSell.ToString();
            txtUpgrade.text = "Upgrade: $" + towerToUpgrade.stats[towerToUpgrade.currentLevel].priceUpgrade.ToString();
            //NextLevel
            txtNextLevel.text = "Level: " + towerToUpgrade.stats[towerToUpgrade.nextLevel].level.ToString();
            txtNextAttack.text = "Attack: " + towerToUpgrade.stats[towerToUpgrade.nextLevel].attack * towerToUpgrade.firePoint.Count;
            txtNextRange.text = "Range: " + towerToUpgrade.stats[towerToUpgrade.nextLevel].range.ToString();
            txtNextSpeed.text = "Speed: " + towerToUpgrade.stats[towerToUpgrade.nextLevel].fireRate.ToString();

            if(towerToUpgrade.stats[towerToUpgrade.currentLevel].level >= 3)
            {
                btnUpgrade.SetActive(false);
                pnlNextStats.SetActive(false);
                pnlMaxStats.SetActive(true);
            }
            else
            {
                btnUpgrade.SetActive(true);
                pnlNextStats.SetActive(true);
                pnlMaxStats.SetActive(false);
            }
        }

        
    }

}
