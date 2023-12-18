using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> objects;

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
    void Start()
    {
        score = 0;
        objectMoveSpeed = 3;
        StartCoroutine(CreateObjectCoroutine());
    }

    // 오브젝트를 생성한다. 시작 위치는 x = 7.5, y = 랜덤
    void CreateObjects()
    {
        int randomIndex = Random.Range(0, objects.Count);
        Instantiate(objects[randomIndex], new Vector3(7.5f, 0, 0), Quaternion.identity);
    }

    private void Update()
    {
        objectMoveSpeed += Time.deltaTime * 0.1f;
    }

    private IEnumerator CreateObjectCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(50 / objectMoveSpeed);
            CreateObjects();
        }
    }
}