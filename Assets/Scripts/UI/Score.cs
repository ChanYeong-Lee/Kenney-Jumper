using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private Text text;

    private void Awake()
    {
        text = GetComponent<Text>();    
        text.text = $"Score: {GameManager.score}";
    }

    public void UpdateScore()
    {
        text.text = $"Score: {GameManager.score}";
    }
}
