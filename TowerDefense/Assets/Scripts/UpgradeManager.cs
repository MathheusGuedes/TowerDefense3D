using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public GameObject upgrade;
    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
    }

    
    void Update()
    {
        if(buildManager.GetTowerToUpgrade() == null)
        {
            upgrade.transform.position = Vector2.Lerp(upgrade.transform.position, new Vector2(-265, upgrade.transform.position.y), Time.fixedDeltaTime);
        }
        else{
            upgrade.transform.position = Vector2.Lerp(upgrade.transform.position, new Vector2(265, upgrade.transform.position.y), Time.fixedDeltaTime);
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {   
            buildManager.SetTowerToUpgrade(null);
        }
    }

}
