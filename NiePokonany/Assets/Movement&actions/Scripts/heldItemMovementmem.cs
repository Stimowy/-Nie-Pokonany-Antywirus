using UnityEngine;

public class heldItemMovementmem : MonoBehaviour
{
    [SerializeField] Transform followedItem;
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, followedItem.position, .05f);
    }
}
