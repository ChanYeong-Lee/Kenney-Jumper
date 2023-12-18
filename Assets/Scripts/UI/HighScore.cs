using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    private Text text;
    private void Awake()
    {
        text = GetComponent<Text>();
        if (GameManager.score > 0)
        {
            if (PlayerPrefs.GetInt("HighScore", 0) < GameManager.score)
            {
                PlayerPrefs.SetInt("HighScore", GameManager.score);
                PlayerPrefs.Save();
            }
        }
        text.text = $"HighScore: {PlayerPrefs.GetInt("HighScore", 0)}";
    }
    
}
