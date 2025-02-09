using UnityEngine;

public class RockDestroyer : MonoBehaviour
{
    [SerializeField] private pickableFinder pickableFinderScript;
    private void Awake()
    {
        pickableFinderScript = GameObject.Find("rayCast").GetComponent<pickableFinder>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log(collision.gameObject.name);
        if (pickableFinderScript != null)
        {
            if (pickableFinderScript.timeOfHolding <= 0.2f && pickableFinderScript.timeOfHolding != 0f && collision.gameObject.tag != "Player")
            {
                Destroy(this.gameObject);
            }
        }
    }
}
