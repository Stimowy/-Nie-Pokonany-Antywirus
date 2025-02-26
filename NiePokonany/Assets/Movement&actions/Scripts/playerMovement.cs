using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Timeline;

public class playerMovement : MonoBehaviour
{
    [SerializeField] movementScript movementSpeed;
    [SerializeField] Transform cameraRotation;
    [SerializeField] Transform rotationDirection;
    [SerializeField] Transform characterModel;
    [SerializeField] Transform direction;
    [SerializeField] colide coliding;
    private void FixedUpdate()
    {
        transform.position += transform.right * Input.GetAxis("Vertical") / movementSpeed.playerSpeed() * -1 * coliding.coliding();
        transform.position += transform.forward * Input.GetAxis("Horizontal") / movementSpeed.playerSpeed() * coliding.coliding();
        
        float directionRotation;
        if(Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            float frontBack = Input.GetAxis("Vertical");
            float leftRight = Input.GetAxis("Horizontal");
            int rot = 0;
            if(leftRight < 0)
            {
                rot = 180;
            }
            //---
            directionRotation = Mathf.Atan(frontBack/leftRight)*-180/Mathf.PI+90+rot;

            transform.eulerAngles = new Vector3(0, cameraRotation.eulerAngles.y, 0);
            cameraRotation.localEulerAngles = new Vector3(cameraRotation.eulerAngles.x,0, cameraRotation.eulerAngles.z);

            rotationDirection.localEulerAngles = new Vector3(rotationDirection.localEulerAngles.x, cameraRotation.localEulerAngles.y+directionRotation, rotationDirection.localEulerAngles.z);
            Vector3 dire = direction.position - transform.position;
            quaternion rotation = Quaternion.LookRotation(dire)*Quaternion.Euler(90f*Vector3.up);
            characterModel.rotation = Quaternion.Lerp(characterModel.rotation, rotation, 5f*Time.deltaTime);
        }
    }
}
//cameraRotation.localEulerAngles.y + (frontBack * 180)+(leftRight*90*frontBack2)