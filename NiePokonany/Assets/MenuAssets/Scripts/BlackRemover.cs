using UnityEngine;

public class BlackRemover : MonoBehaviour
{
    public GameObject gObj;
    public void Disabler()
    {
        gObj.SetActive(false);
    }
}
