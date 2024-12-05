using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    public GameManagerLogic manager;

    AudioSource audio;

    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    public void ClickStart()
    {
        SceneManager.LoadScene("Stage");
    }

    public void ClickResume()
    {
        Time.timeScale = 1.0f;
        manager.PauseText.gameObject.SetActive(false);
        manager.ResumeButton.SetActive(false);
        manager.RestartButton.SetActive(false);
        manager.PausePannel.SetActive(false);
        manager.BackButton.SetActive(false);
        manager.MuteButton.SetActive(false);
    }

    public void ClickRestart()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Stage");
    }

    public void ClickBack()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("StartScene");
    }

    public void Mute()
    {
        if (audio.mute)
            audio.mute = false;

        else
            audio.mute = true;

    }

    public void Quit()
    {
        Application.Quit();
    }

    public void HappyEnd()
    {
        SceneManager.LoadScene("Ending3");
    }

    public void NormalEnd()
    {
        SceneManager.LoadScene("Ending1");
    }

    public void SadEnd()
    {
        SceneManager.LoadScene("Ending2");
    }

    public void BadEnd()
    {
        SceneManager.LoadScene("Ending4");
    }
}
