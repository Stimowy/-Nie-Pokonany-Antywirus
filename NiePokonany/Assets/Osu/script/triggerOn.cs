using UnityEngine;

public class triggerOn : MonoBehaviour
{
    private bool isTrigger = false;
    private string tagg;

    private void OnTriggerEnter(Collider other)
    {
        isTrigger = true;
        tagg = other.tag;
    }

    private void OnTriggerExit(Collider other)
    {
        isTrigger = false;
        tagg = "";
    }

    public bool IsTrigger()
    {
        return isTrigger;
    }

    public int IsName()
    {
        if (tagg == "file")
        {
            return 1;
        }
        else if (tagg == "bomb")
        {
            return 2;
        }
        else
        {
            return 0;
        }
    }

    public void SetTrigger()
    {
        isTrigger = false;
        tagg = "";
    }
}
