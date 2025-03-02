using UnityEngine;
using UnityEngine.SceneManagement;
public class ReloadLevel : MonoBehaviour
{
    public Transform player, center;
    private void Update()
    {
        //Debug.Log(Vector3.Distance(player.position, center.position));
        if (Vector3.Distance(player.position, center.position) > 80)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
