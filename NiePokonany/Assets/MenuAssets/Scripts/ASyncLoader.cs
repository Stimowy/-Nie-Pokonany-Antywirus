using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ASyncLoader : MonoBehaviour
{
    public GameObject loadingScreen;
    public void LoadLevelStraight(string levelToLoad)
    {
        loadingScreen.SetActive(true);
        StartCoroutine(LoadLevelASync(levelToLoad));
    }
    public void LoadLevelUndirectly()
    {
        if (PlayerPrefs.HasKey("Progress"))
        {
            loadingScreen.SetActive(true);
            StartCoroutine(LoadLevelASync(PlayerPrefs.GetString("Progress")));
        }
    }
    public void DeleteSave()
    {
        PlayerPrefs.DeleteKey("Progress");
    }
    IEnumerator LoadLevelASync(string levelToLoad)
    {
        AsyncOperation loadOperation = SceneManager.LoadSceneAsync(levelToLoad);
        while (!loadOperation.isDone)
        {
            yield return null;
        }
    }
}
