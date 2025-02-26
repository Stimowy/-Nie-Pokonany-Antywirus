using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.UIElements;

public class RockSettings : MonoBehaviour
{
    [SerializeField] private GameObject rock;

    int maxRock = 12;
    [SerializeField] private float time = 0f;
    private float timer = 0f;

    private int countRock;

    private void Start()
    {
        timer = time;
    }

    private void FixedUpdate()
    {
        if (timer <= 0)
        {
            CreateRock();
        }
        else
        {
            timer -= Time.deltaTime;
        }

        countRock = GameObject.FindGameObjectsWithTag("pickable").Length;
    }

    private void CreateRock()
    {
        if(countRock < maxRock)
        {
            int X = Random.Range(30, 170) * -1;
            int Y = Random.Range(-75, 65);

            Vector3 pos = new Vector3(X, 55, Y);
            Instantiate(rock, pos, Quaternion.identity);

            timer = time;
        }
    }
}
