using UnityEngine;

public class cameraClipingManager : MonoBehaviour
{
    [SerializeField] private cameraCliping leftRay;
    [SerializeField] private cameraCliping rightRay;
    [SerializeField] private GameObject camera;
    [SerializeField] float len;
    [SerializeField] float correction;

    void Update()
    {
        float left = len - leftRay.distance() / correction;
        float right = len - rightRay.distance() / correction;
        if(left > right)
        {
            camera.transform.localPosition = new Vector3(len - left, camera.transform.localPosition.y, camera.transform.localPosition.z);
        } else
        {
            camera.transform.localPosition = new Vector3(len - right, camera.transform.localPosition.y, camera.transform.localPosition.z);
        }
    }
}
