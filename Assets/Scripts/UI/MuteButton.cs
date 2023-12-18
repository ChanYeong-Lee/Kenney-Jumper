using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuteButton : MonoBehaviour
{
    public Sprite on;
    public Sprite off;

    Button sp;

    void Awake()
    {
        sp = GetComponent<Button>();

        if (PlayerPrefs.GetInt("Mute", 0) == 1)
        {
            AudioListener.volume = 0;
            sp.image.sprite = off;
        }
        else
        {
            AudioListener.volume = 1;
            sp.image.sprite = on;
        }
    }

    public void SetMute()
    {
        if (PlayerPrefs.GetInt("Mute", 0) == 0)
        {
            AudioListener.volume = 0;
            PlayerPrefs.SetInt("Mute", 1);
            sp.image.sprite = off;
        }
        else
        {
            AudioListener.volume = 1;
            PlayerPrefs.SetInt("Mute", 0);
            sp.image.sprite = on;
        }

        PlayerPrefs.Save();
    }
}