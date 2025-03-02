using UnityEngine;
using UnityEngine.SceneManagement;

public class EndOfMaze : MonoBehaviour
{
    public Transform player, center;
    public ASyncLoader loader;
    private void Update()
    {
        Debug.Log(Vector3.Distance(player.position, center.position));
        if (Vector3.Distance(player.position, center.position) <= 2.5f)
        {
            loader.LoadLevelStraight("osuPrinter");
        }
    }
}
