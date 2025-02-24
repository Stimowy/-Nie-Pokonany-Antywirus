using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
public class MenuManager : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public ASyncLoader loader;
    public Button btnCon;
    private void Update()
    {
        //Debug.Log(videoPlayer.frameCount);
        //Debug.Log(videoPlayer.frame);
        if(videoPlayer.frame == 969)
        {
            loader.LoadLevelStraight("movementTest");
        }
        if (PlayerPrefs.HasKey("Progress"))
        {
            btnCon.interactable = true;
        }
        else
        {
            btnCon.interactable = false;
        }
    }
    public void PlayNewGame()
    {
        videoPlayer.gameObject.SetActive(true);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
