using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public GameObject upgrade;
    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
        upgrade.transform.position = new Vector2(-upgrade.GetComponent<RectTransform>().rect.width/2, upgrade.transform.position.y);
    }

    
    void Update()
    {
        if(buildManager.GetTowerToUpgrade() == null)
        {
            upgrade.transform.position = Vector2.Lerp(upgrade.transform.position, new Vector2(-upgrade.GetComponent<RectTransform>().rect.width/2, upgrade.transform.position.y), Time.fixedDeltaTime*2);
        }
        else{
            upgrade.transform.position = Vector2.Lerp(upgrade.transform.position, new Vector2(upgrade.GetComponent<RectTransform>().rect.width/2, upgrade.transform.position.y), Time.fixedDeltaTime*2);
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {   
            buildManager.SetTowerToUpgrade(null);
        }
    }

}
