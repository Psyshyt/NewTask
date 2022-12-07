using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerSecond : MonoBehaviour
{
    public float timeStart;
    public Text textTimer;


    bool timerRunning = false;
    // Start is called before the first frame update
    void Start()
    {
        textTimer.text = timeStart.ToString("F2");
    }

    // Update is called once per frame
    void Update()
    {
        if (timerRunning == true)
        {
            timeStart += Time.deltaTime;
            textTimer.text = timeStart.ToString("F2");
        }
    }


    public void ButtonTimer()
    {
        timerRunning = !timerRunning;
    }
}
