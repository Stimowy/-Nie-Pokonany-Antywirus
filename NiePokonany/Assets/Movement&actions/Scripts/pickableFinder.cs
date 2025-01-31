using UnityEngine;

public class pickableFinder : MonoBehaviour
{
    private void FixedUpdate()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 5f))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward)*5, Color.red);
            if (hit.collider.CompareTag("pickable") && !Input.GetMouseButton(0))
            {
                Debug.Log("niga");
            }
        }

    }
}
