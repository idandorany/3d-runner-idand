using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicManager : MonoBehaviour
{
    public Toggle musicToggle;
    public AudioSource musicAudioSource;

    private void Start()
    {
        // Kay�tl� m�zik durumunu y�kle
        if (PlayerPrefs.HasKey("MusicState"))
        {
            int musicState = PlayerPrefs.GetInt("MusicState");
            musicToggle.isOn = musicState == 1 ? true : false;
            UpdateMusicState(musicToggle.isOn);
        }

        // Toggle'�n durumu de�i�ti�inde �al��acak fonksiyonu atay�n
        musicToggle.onValueChanged.AddListener(OnMusicToggleChanged);
    }

    private void OnMusicToggleChanged(bool isOn)
    {
        UpdateMusicState(isOn);

        // M�zik durumunu kaydet
        PlayerPrefs.SetInt("MusicState", isOn ? 1 : 0);
        PlayerPrefs.Save();
    }

    private void UpdateMusicState(bool isMusicOn)
    {
        if (isMusicOn)
        {
            musicAudioSource.Play();
        }
        else
        {
            musicAudioSource.Stop();
        }
    }
}

