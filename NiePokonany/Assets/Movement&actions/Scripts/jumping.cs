using UnityEngine;

public class jumping : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] groundChecker ground;
    [SerializeField] Rigidbody rigidbody;
    [SerializeField] movementScript jumpingPower;

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (ground.IsOnGround())
        {
            rigidbody.AddForce(new Vector3(0f, jumpingPower.jumpPower(), 0f));    
        }
    }
}
