using UnityEngine;

public class HoleScript : MonoBehaviour
{
    public GameObject bugObj;
    public GameObject destroyedNest;
    [SerializeField]private pickableFinder pickableFinderScript;
    private Vector3 vec;
    private Quaternion qua;
    private void Awake()
    {
        vec = this.transform.position;
        qua = this.transform.rotation;
        pickableFinderScript = GameObject.Find("rayCast").GetComponent<pickableFinder>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "pickable")
        {
            //Debug.Log(collision.gameObject.name);
            if (pickableFinderScript != null)
            {
                if (pickableFinderScript.timeOfHolding >= 2f)
                {
                    Destroy(collision.gameObject);
                    Instantiate(destroyedNest, vec, qua);
                    Destroy(this.gameObject);
                }
            }
        }
    }
    public void Spawn()
    {
        Instantiate(bugObj,vec,qua);
    }
}
