using UnityEngine;
using UnityEngine.SceneManagement;
public class SaveAndLoadSystem : MonoBehaviour
{
    private void Start()
    {
        //Debug.Log(SceneManager.GetActiveScene().name);
        if(SceneManager.GetActiveScene().name != "SampleScene")
        {
            PlayerPrefs.SetString("Progress", SceneManager.GetActiveScene().name);
        }
    }
}
