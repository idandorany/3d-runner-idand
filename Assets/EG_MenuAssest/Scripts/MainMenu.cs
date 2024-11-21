using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public GameObject SettingsPanel;
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    void Start()
    {
        SettingsPanel.SetActive(false); // Paneli ba�lang��ta devre d��� b�rak
    }

    public void OpenSettingsPanel()
    {
        SettingsPanel.SetActive(true);
    }
    public void CloseSettingsPanel()
    {
        SettingsPanel.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit(); 
    }

    public void Setaudio(float value)
    {
        AudioListener.volume = value;
    }
}
