using UnityEngine;

public class cameraMovement : MonoBehaviour
{
    [SerializeField] float mouseSensitivityX;
    [SerializeField] float mouseSensitivityY;
    [SerializeField] float maxVertical;
    [SerializeField] float minVertial;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void FixedUpdate()
    {

        float zRotation = transform.eulerAngles.z;
        float zMouseMove = Input.GetAxis("Mouse Y");

        if(zRotation <= maxVertical)
        { 
            zRotation = Mathf.Clamp((zRotation-zMouseMove*mouseSensitivityY), -1f, maxVertical-1);
        } else
        {
            zRotation = Mathf.Clamp((zRotation - zMouseMove * mouseSensitivityY), 360f-minVertial, 361f);
        }
        //prawo lewo
        transform.eulerAngles += new Vector3(0f, Input.GetAxis("Mouse X") * mouseSensitivityX, 0f);

        //góra dó³
        transform.eulerAngles = new Vector3(0f, transform.eulerAngles.y, zRotation);
    }
    
}
