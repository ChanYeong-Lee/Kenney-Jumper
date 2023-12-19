using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> objects;

    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            return instance;
        }
    }

    public static int score;
    public static float objectMoveSpeed;
    public Score scoreText;
    public int Score
    {
        set
        {
            score = value;
            scoreText.UpdateScore();
        }
        get
        {
            return score;
        }
    }

    // 시작할 때 score를 0으로 초기화
    void Awake()
    {
        instance = this;

        score = 0;
        objectMoveSpeed = 3;
        Instantiate(objects[0], new Vector3(-6, -2.1f, 0), Quaternion.identity);
        StartCoroutine(ScoreCoroutine());
    }

    private void Update()
    {
        objectMoveSpeed += Time.deltaTime / 10;
    }
    public void GenerateObject()
    {
        int randomIndex = Random.Range(0, objects.Count);
        Instantiate(objects[randomIndex], new Vector3(16, -2.1f, 0), Quaternion.identity);
    }

    private IEnumerator ScoreCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            Score++;
        }
    }

    public void GameOver()
    {
        SceneLoader.Instance.LoadScene("MainMenuScene");
    }
}