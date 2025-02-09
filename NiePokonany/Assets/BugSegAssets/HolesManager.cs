using UnityEngine;

public class HolesManager : MonoBehaviour
{
    public GameObject[] holes;
    private int amountOfBugs = 0;
    private int maxAmountOfBugs = 0;
    private float timer = 7f;
    private void Awake()
    {
        maxAmountOfBugs = holes.Length;
    }
    private void Update()
    {
        if(amountOfBugs < maxAmountOfBugs)
        {
            if(timer <= 0f)
            {
                BugSpawn();
            }
            timer -= Time.deltaTime;
        }
    }
    private void BugSpawn()
    {
        int randomSpot = 0;
        int amountOfNulls = 0;
        for (int i = 0; i < holes.Length; i++)
        {
            if (holes[i] == null)
            {
                amountOfNulls++;
            }
        }
        if(amountOfNulls < holes.Length)
        {
            while (true)
            {
                randomSpot = Random.Range(0, holes.Length);
                if (holes[randomSpot] != null)
                {
                    holes[randomSpot].gameObject.GetComponent<HoleScript>().Spawn();
                    amountOfBugs++;
                    timer = 7f;
                    break;
                }
            }
        }
    }
}
