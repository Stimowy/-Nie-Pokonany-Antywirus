using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
public class EndingManager : MonoBehaviour
{
    public GameObject endGameChat;
    public GameObject choose;
    public GameObject goodEnding;
    public GameObject badEnding;
    public GameObject lesson;
    public GameObject bObj;
    private bool bb = false;
    private void Update()
    {
        Debug.Log(endGameChat.GetComponent<VideoPlayer>().frame);
        if (!bObj.activeInHierarchy && !bb)
        {
            endGameChat.SetActive(true);
            if(endGameChat.GetComponent<VideoPlayer>().frame == 257)
            {
                endGameChat.SetActive(false);
                choose.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                bb = true;
            }
        }
        if (goodEnding.GetComponent<VideoPlayer>().frame == 177)
        {
            goodEnding.SetActive(false);
            lesson.SetActive(true);
        }
        if (badEnding.GetComponent<VideoPlayer>().frame == 351)
        {
            badEnding.SetActive(false);
            lesson.SetActive(true);
        }
        if (lesson.GetComponent<VideoPlayer>().frame == 146)
        {
            lesson.SetActive(false);
            SceneManager.LoadScene("SampleScene");
        }
    }
    public void GoodEndingOption()
    {
        choose.SetActive(false);
        goodEnding.SetActive(true);
    }
    public void BadEndingOption()
    {
        choose.SetActive(false);
        badEnding.SetActive(true);
    }
}
