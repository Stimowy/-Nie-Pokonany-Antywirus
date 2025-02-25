using UnityEngine;

public class deleteTrigger : MonoBehaviour
{
    [SerializeField] private GameObject obj;

    [SerializeField] private pointCounter points;

    public void OnTriggerEnter(Collider other)
    {
        obj = other.gameObject;
        Destroy(obj);

        if(other.tag == "file")
        {
            points.DiviseScore();
        }
    }
}