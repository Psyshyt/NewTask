using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class TimeScore : MonoBehaviour
{

    public float Running1;

    public Text Run1;

    public GameObject TimeHud;

    public Text textTimer;

    public  List<float> Score;

    public  float timeStart;

    private void Update() 
    {
        if (Raycast.timerRunning == true)
            {
                timeStart += Time.deltaTime;
                textTimer.text = timeStart.ToString("F2");
                TimeHud.SetActive(true);
            }   
            if(Raycast.Finish == true && Input.GetMouseButtonDown(0))
            {
                if(timeStart != 0)
                {
                    Score.Add(timeStart);
                    Raycast.Finish = false;
                    Score.Sort((x, y) => -y.CompareTo(x));
                }
                Run1.text = timeStart.ToString("F2");
                TimeHud.SetActive(false);
                foreach (float Score in Score) 
                {  
                    if (timeStart != Score) 
                        {   
                            Run1.text += "\n";
                            Run1.text += Score;  
                        }                                           
                }
                timeStart = 0;
            }
       
    }

    private void List() 
    {

    }

}
