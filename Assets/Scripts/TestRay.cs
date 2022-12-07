using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestRay : MonoBehaviour
{
    public Vector3 RestartGame;

    public GameObject Leader;

    public GameObject RestartButton;

    public Vector3 RestartRun;

    public GameObject Particles;
    
    public float timeStart;

    public float Running1;

    public float Running2;

    public Text Run1;

    public Text Run2;

    public Text textTimer;

    public GameObject WallStart;

    public GameObject TimeHud;

    bool timerRunning = false;

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
                Run1.text = Running1.ToString("F2");
                Run2.text = Running2.ToString("F2");
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
                                    Running1 = timeStart;
                                    Run1.text = Running1.ToString("F2");    
                                    WallStart.SetActive(true);
                                    Particles.SetActive(true);
                                    timerRunning = false;
                                    RestartButton.SetActive(true);
                                    Leader.SetActive(true);
                                    Running1 = Running1;

                                   
                                }    
                                    if(_hit.transform.tag == "ButtonStart")
                                        {       
                                            timerRunning = true;
                                            WallStart.SetActive(false);
                                            TimeHud.SetActive(true);                                                            
                                        } 

                                        if(_hit.transform.tag == "Restart")
                                        {   
                                            Running2 = timeStart;
                                            Particles.SetActive(false);
                                            timeStart = 0;
                                            TimeHud.SetActive(false);
                                            transform.position = RestartRun;               
                                            Run2.text = Running2.ToString("F2");
                                            Leader.SetActive(false);
                                            RestartButton.SetActive(false);
                                        }       
                            if(_hit.transform.tag == "RestartGame")
                            {
                                transform.position = RestartGame;  
                            }    
                            
                        }    

         
               }
    }    
}
                         