using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class TestRay : MonoBehaviour
{   
    public Vector3 RestartGame;

    public GameObject Leader;

    public GameObject RestartButton;

    public Vector3 RestartRun;

    public GameObject Particles;
    
    public float timeStart;

    public float Running1;

    public Text Run1;

    public Text textTimer;

    public GameObject WallStart;

    public GameObject TimeHud;

    bool timerRunning = false;

    public List<float> Score;

    private void Start()
    {
        textTimer.text = timeStart.ToString("F2");
    }

    private void Update()
    {
        
        if (timerRunning == true)
            {
                timeStart += Time.deltaTime;
                textTimer.text = timeStart.ToString("F2");
            }
            if(Input.GetMouseButtonDown(0))
                {
                    Ray ray = new Ray(transform.position, transform. forward);

                    RaycastHit _hit;

                    Debug.DrawRay(transform.position, transform.forward * 5f, Color.blue); 

                    if(Physics.Raycast(ray, out _hit, Mathf.Infinity))
                        {      
                            if(_hit.transform.tag == "ButtonFinish")   
                                { 
                                    Run1.text = timeStart.ToString("F2");                            
                                    WallStart.SetActive(true);
                                    Particles.SetActive(true);
                                    timerRunning = false;
                                    RestartButton.SetActive(true);
                                    Leader.SetActive(true);
                                    Score.Add(timeStart);
                                    foreach (float Score in Score)
                                            {
                                                if (timeStart != Score) 
                                                {   
                                                    Run1.text += "\n";
                                                    Run1.text += Score;                                           
                                                }
                                            }
                                       
                                }    
                                    if(_hit.transform.tag == "ButtonStart")
                                        {   
                                            timeStart = 0; 
                                            timerRunning = true;
                                            WallStart.SetActive(false);
                                            TimeHud.SetActive(true);                                               
                                        } 

                                        if(_hit.transform.tag == "Restart")
                                        {  
                                            Particles.SetActive(false);
                                            TimeHud.SetActive(false);
                                            transform.position = RestartRun;               
                                            Leader.SetActive(false);
                                            Score.Sort((x, y) => -y.CompareTo(x));
                                            
                                        }       
                            if(_hit.transform.tag == "RestartGame")
                            {
                                transform.position = RestartGame;  
                            }    
                            
                        }    

         
               }
    }    
}
                         