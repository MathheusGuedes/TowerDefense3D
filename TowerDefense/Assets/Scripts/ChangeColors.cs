using UnityEngine;
using UnityEngine.UI;

public class ChangeColors : MonoBehaviour
{   
    [Header("Gradient")]
    public bool gradient;
    public Gradient myGradient;
    public float speedGradient = 10f;

    [Header("Matiz")]
    public bool matiz;
    public float h = 0;
    public float speed = 10f;

    public void Update()
    {
        if(gradient)
        {
            matiz = false;
            float t = Mathf.PingPong(Time.time * speedGradient / 10, 1f);
            GetComponent<Image>().color = myGradient.Evaluate(t);
        }
        if(matiz)
        {
            gradient = false;
            h += Time.deltaTime * speed / 10;
            GetComponent<Image>().color = Color.HSVToRGB(h, 1, 1);
            if(h >= 1) h = 0;
        }
    }

}
