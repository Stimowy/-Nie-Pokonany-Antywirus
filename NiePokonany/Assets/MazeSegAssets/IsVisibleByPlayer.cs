using UnityEngine;

public class IsVisibleByPlayer : MonoBehaviour
{
    public GameObject[] pV;
    public GameObject playerRayC;
    private void Awake()
    {
        pV = GameObject.FindGameObjectsWithTag("CM");
    }
    void Update()
    {
        for (int i = 0; i < pV.Length; i++)
        {
            //Debug.DrawLine(playerRayC.transform.position, pV[i].transform.position,Color.red);
            RaycastHit rH;
            if(Physics.Linecast(playerRayC.transform.position, pV[i].transform.position, out rH))
            {
                Debug.Log(rH.collider.gameObject.name);
                if (rH.collider.gameObject.name == "ByPlayerVisible")
                {
                    pV[i].GetComponent<CMLinker>().IsVisible(true);
                }
                else
                {
                    pV[i].GetComponent<CMLinker>().IsVisible(false);
                }
            }
        }
    }
}
