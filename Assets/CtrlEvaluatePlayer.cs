using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CtrlEvaluatePlayer : MonoBehaviour
{
    public static CtrlEvaluatePlayer Ins;
    public Text time;
    private void Awake()
    {
        if (Ins != null)
        {

            Destroy(gameObject);
        }
        else
        {
            Ins = null;
        }
    }

    public static float timeInSeconds;

    private void Update()
    {

        if (GameManager.Ins.isGameOver || GameManager.Ins.isGamePause)
            return;

            timeInSeconds += Time.deltaTime;
            var ts = System.TimeSpan.FromSeconds(timeInSeconds);
            time.text = "Time : "+ string.Format("{0:00}:{1:00}", ts.Minutes, ts.Seconds);

       
    }

    public static string GetTime()
    {
        var ts = System.TimeSpan.FromSeconds(timeInSeconds);
        return string.Format("{0:00}:{1:00}", ts.Minutes, ts.Seconds);
    }

}
