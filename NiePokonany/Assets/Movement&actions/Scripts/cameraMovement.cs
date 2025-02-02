using UnityEngine;

public class cameraMovement : MonoBehaviour
{
    [SerializeField] float mouseSensitivityX;
    [SerializeField] float mouseSensitivityY;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void FixedUpdate()
    {
        float zRotation = transform.eulerAngles.z;
        float zMouseMove = Input.GetAxis("Mouse Y");

        zRotation = Mathf.Clamp((zRotation-zMouseMove*mouseSensitivityY), 0f, 90f);

        transform.eulerAngles += new Vector3(0f, Input.GetAxis("Mouse X") * mouseSensitivityX, 0f);
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, zRotation);
    }
    
}
