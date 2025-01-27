using UnityEngine;

public class jumpTest : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] groundChecker ground;
    [SerializeField] Rigidbody rigidbody;

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        if (ground.IsOnGround())
        {
            rigidbody.AddForce(new Vector3(0f, 120, 0f));    
        }
    }
}
