using UnityEngine;

public class groundChecker : MonoBehaviour
{
    private bool isOnGround = false;

    private void OnTriggerEnter(Collider ground)
    {
        if (ground.CompareTag("ground"))
        {
            isOnGround = true;    
        }
    }
    private void OnTriggerExit(Collider other)
    {
        isOnGround = false;
    }

    public bool IsOnGround()
    {
        return isOnGround;
    }
}
