using UnityEngine;

public class CameraController : MonoBehaviour
{
    private bool doMovement = true;

    public float panSpeed = 30f;
    public float panBorderThickness = 10f;
    public float scrollSpeed = 5f;

    public float minScrollingY = 10f;
    public float maxScrollingY = 130f;

    public float rotateX = 89;

    public float rotateSpeed = 2f;
    public Vector3 rotation;

    public bool moveMouse = false;
    
    void Start()
    {
        rotation = new Vector3(transform.eulerAngles.y, transform.eulerAngles.x, 0f);
    }
    void Update()
    {
        if(!doMovement)
            return;

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            doMovement = !doMovement;
        }

        if(Input.GetKeyDown(KeyCode.R))
        {
            moveMouse = !moveMouse;
        }      
        
        if(moveMouse)
        {
            if(Input.GetKey(KeyCode.W) || Input.mousePosition.y >= Screen.height - panBorderThickness)
            {
                transform.Translate(Vector3.forward * panSpeed *Time.fixedDeltaTime, Space.Self);
            }
            if(Input.GetKey(KeyCode.S) || Input.mousePosition.y <= panBorderThickness)
            {
                transform.Translate(Vector3.back * panSpeed *Time.fixedDeltaTime, Space.Self);
            }
            if(Input.GetKey(KeyCode.A) || Input.mousePosition.x <= panBorderThickness)
            {
                transform.Translate(Vector3.left * panSpeed *Time.fixedDeltaTime, Space.Self);
            }
            if(Input.GetKey(KeyCode.D) || Input.mousePosition.x >= Screen.width - panBorderThickness)
            {
                transform.Translate(Vector3.right * panSpeed *Time.fixedDeltaTime, Space.Self);
            }
        }
        else
        {
            if(Input.GetKey(KeyCode.W))
            {
                transform.Translate(Vector3.forward * panSpeed *Time.fixedDeltaTime, Space.Self);
            }
            if(Input.GetKey(KeyCode.S))
            {
                transform.Translate(Vector3.back * panSpeed *Time.fixedDeltaTime, Space.Self);
            }
            if(Input.GetKey(KeyCode.A))
            {
                transform.Translate(Vector3.left * panSpeed *Time.fixedDeltaTime, Space.Self);
            }
            if(Input.GetKey(KeyCode.D))
            {
                transform.Translate(Vector3.right * panSpeed *Time.fixedDeltaTime, Space.Self);
            }
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        Vector3 pos = transform.position;
        pos.y -= scroll * 1000 * scrollSpeed * Time.fixedDeltaTime;
        pos.y = Mathf.Clamp(pos.y, minScrollingY, maxScrollingY);

        transform.position = pos;
        
        if(Input.GetMouseButton(1))
        {   
            Vector3 input = new Vector3(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y")*-1,0);

            Vector3 rotVelocity = input * rotateSpeed * 100;

            rotation += rotVelocity * Time.fixedDeltaTime;

            rotation.y = Mathf.Clamp(rotation.y, -90, 90);
            transform.eulerAngles = new Vector3(rotation.y, rotation.x, 0f);
        }

    }
}
