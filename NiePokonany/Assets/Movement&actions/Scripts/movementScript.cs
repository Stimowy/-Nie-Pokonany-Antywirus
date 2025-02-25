using UnityEngine;

public class movementScript : MonoBehaviour
{
    public float playerSpeed()
    {
        if (Input.GetKey("left shift"))
        {
            return 8f;
        }
        return 18f;
    }
    public float jumpPower() {
        if (Input.GetKey("space"))
        {
            return 170f;
        }
        return 120f;
    }
}
