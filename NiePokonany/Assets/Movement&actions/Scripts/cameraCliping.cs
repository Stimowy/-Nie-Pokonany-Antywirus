using UnityEngine;

public class cameraCliping : MonoBehaviour
{
    [SerializeField] float len;
    
    public RaycastHit hit;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    private void Update()
    {
        
        Vector3 starting = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        Debug.DrawRay(starting, transform.right * len, Color.red);
        Ray ray = new Ray(starting, transform.right * len);
        Physics.Raycast(ray, out hit, len);
    }
    public float distance()
    {
        return hit.distance;
    }
}
