using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAspect : MonoBehaviour
{
    void Start()
    {
        // ���� ī�޶��� ������ 16 : 9�� �����Ѵ�.
        Camera.main.aspect = 16 / 9f;
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        Time.timeScale = 1;
    }

    void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
