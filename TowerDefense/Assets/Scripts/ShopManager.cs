using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public GameObject shop;
    public bool shopIsOpen = true;
    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
    }
    
    void Update()
    {
        if(shopIsOpen)
        {
            shop.transform.position = Vector2.Lerp(shop.transform.position, new Vector2(shop.transform.position.x, -200), Time.fixedDeltaTime);
        }
        else{
            shop.transform.position = Vector2.Lerp(shop.transform.position, new Vector2(shop.transform.position.x, 130), Time.fixedDeltaTime);
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            buildManager.SetTowerToBuild(null);
        }
    }

    public void OpenShop()
    {
        shopIsOpen = !shopIsOpen;
    }
    
}
