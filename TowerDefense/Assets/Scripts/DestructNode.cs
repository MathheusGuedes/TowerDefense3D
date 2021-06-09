using UnityEngine;

public class DestructNode : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Node")
        {
            Destroy(other.gameObject);
        }
    }

}
