using UnityEngine;

public class DBR : MonoBehaviour
{
    GameObject deleteRock;
    [SerializeField] GameObject rock;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "pickable")
        {
            deleteRock = other.gameObject;
            Destroy(deleteRock);
            CreateRock();
        }
    }
    private void CreateRock()
    {
        int X = Random.Range(30, 170) * -1;
        int Y = Random.Range(-75, 65);

        Vector3 pos = new Vector3(X, 55, Y);
        Instantiate(rock, pos, Quaternion.identity);
    }
}
