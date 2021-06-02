using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public GameObject shop;
    public bool shopClose = true;
    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
        shop.transform.position = new Vector2(shop.transform.position.x, -shop.GetComponent<RectTransform>().rect.height/2);
    }
    
    void Update()
    {  
        if(shopClose)
        {
            shop.transform.position = Vector2.Lerp(shop.transform.position, new Vector2(shop.transform.position.x, -shop.GetComponent<RectTransform>().rect.height/2), Time.fixedDeltaTime*2);
        }
        else{
            shop.transform.position = Vector2.Lerp(shop.transform.position, new Vector2(shop.transform.position.x, shop.GetComponent<RectTransform>().rect.height/2), Time.fixedDeltaTime*2);
        }

        if(buildManager.GetTowerToUpgrade() != null)
        {
            shop.transform.position = Vector2.Lerp(shop.transform.position, new Vector2(shop.transform.position.x, -shop.GetComponent<RectTransform>().rect.height/2), Time.fixedDeltaTime*2);
            shopClose = true;
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            buildManager.SelectTowerToBuild(null);
        }
    }

    public void OpenShop()
    {   
        buildManager.SetTowerToUpgrade(null);
        shopClose = !shopClose;
    }
    
}
