using UnityEngine;

public class HolesManager : MonoBehaviour
{
    public GameObject[] holes;
    public int amountOfNulls = 0;
    public ASyncLoader loader;
    public int amountOfBugs = 0;
    public int maxAmountOfBugs = 0;
    public float timer = 7f;
    private void Awake()
    {
        maxAmountOfBugs = holes.Length;
    }
    private void Update()
    {
        maxAmountOfBugs = holes.Length - amountOfNulls;
        if (amountOfBugs < maxAmountOfBugs)
        {
            if(timer <= 0f)
            {
                BugSpawn();
            }
            timer -= Time.deltaTime;
        }
        if(maxAmountOfBugs <= 0)
        {
            loader.LoadLevelStraight("Maze");
        }
    }
    private void BugSpawn()
    {
        int randomSpot = 0;
        for (int i = 0; i < holes.Length; i++)
        {
            if (holes[i] == null)
            {
                amountOfNulls++;
            }
        }
        if (amountOfNulls < holes.Length)
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
