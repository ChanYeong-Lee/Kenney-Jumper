using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAspect : MonoBehaviour
{
    void Start()
    {
        // 메인 카메라의 비율을 16 : 9로 변경한다.
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
