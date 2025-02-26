using UnityEngine;

public class colide : MonoBehaviour
{
    private bool colid = false;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("jajco");
        colid = true;
    }
    private void OnTriggerExit(Collider other)
    {
        colid = false;
    }
    public int coliding()
    {
        if (colid) {
            return 0;
        }
        return 1;
    }
}
