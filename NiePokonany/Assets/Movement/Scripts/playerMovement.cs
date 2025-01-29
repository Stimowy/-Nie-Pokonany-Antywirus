using UnityEngine;

public class playerMovement : MonoBehaviour
{
    [SerializeField] float movementSpeed;
    [SerializeField] Transform cameraRotation;
    private void FixedUpdate()
    {
        transform.position += transform.right * Input.GetAxis("Vertical") / movementSpeed * -1;
        transform.position += transform.forward * Input.GetAxis("Horizontal") / movementSpeed;
        if(Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            Debug.Log(cameraRotation.transform.eulerAngles.y);

            transform.eulerAngles = new Vector3(0, cameraRotation.eulerAngles.y, 0);
            cameraRotation.localEulerAngles = new Vector3(cameraRotation.eulerAngles.x,0, cameraRotation.eulerAngles.z);
        }
    }
}
