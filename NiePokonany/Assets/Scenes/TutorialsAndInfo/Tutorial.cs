using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public GameObject gVol;
    public GameObject blackScreen;
    private void Awake()
    {
        gVol = GameObject.Find("TutorialVol");
        blackScreen = GameObject.Find("BlackEnter");
    }
    private void Update()
    {
        if (!blackScreen.activeInHierarchy)
        {
            Time.timeScale = 0;
            if (Input.anyKeyDown)
            {
                Time.timeScale = 1;
                gVol.SetActive(false);
                this.gameObject.SetActive(false);
            }
        }
    }
}
