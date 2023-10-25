using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenuScript : MonoBehaviour
{
    public static bool mute = false;
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void PlayGame()
    {
        Time.timeScale = 1;
        FindObjectOfType<SoundsManager>().StopSound("Steps");

        SceneManager.LoadScene("SampleScene");
    }
    public void OptionsMenu()
    {
        SceneManager.LoadScene("Options");
    }
    public void HowToPlay()
    {
        SceneManager.LoadScene("HowToPlay");
    }
    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }
    public void ToggleMute()
    {
        if (mute)
        {
            print("Unmuted");
            mute = false;
            AudioListener.volume = 1; // Unmute audio
        }
        else
        {
            print("Muted");
            mute = true;
            AudioListener.volume = 0; // Mute audio
        }
    }

    public bool GetMuteStatus()
    {
        return mute;
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");

    }    
    public void BackToOptions()
    {
        SceneManager.LoadScene("Options");

    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
