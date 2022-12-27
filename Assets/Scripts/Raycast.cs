using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class Raycast : MonoBehaviour
{     
    public Vector3 RestartRun;

    public Vector3 RestartGame;

    private TimeScore ScoreScript;

    public GameObject Leader;

    public GameObject RestartButton;

    public GameObject Particles;

    public GameObject WallStart;


    public static bool timerRunning = false;

    public static bool Finish = false;

    public static bool Start = false;

    

    private void Update()
    {
                if(Input.GetMouseButtonDown(0))
                    {
                        Ray ray = new Ray(transform.position, transform. forward);

                        RaycastHit _hit;

                        Debug.DrawRay(transform.position, transform.forward * 5f, Color.blue); 

                        if(Physics.Raycast(ray, out _hit, Mathf.Infinity))
                            {      
                                if(_hit.transform.tag == "ButtonFinish")   
                                    {                         
                                        WallStart.SetActive(true);
                                        Particles.SetActive(true);
                                        RestartButton.SetActive(true);
                                        Leader.SetActive(true);
                                        timerRunning = false;
                                        Start = false; 
                                        Finish = true;
                                        
                                    }    
                                        if(_hit.transform.tag == "ButtonStart")
                                            {   
                                                WallStart.SetActive(false);   
                                                timerRunning = true;  
                                                RestartButton.SetActive(false);
                                                Start = true;                                              
                                            } 

                                            if(_hit.transform.tag == "Restart")
                                            {  
                                                Particles.SetActive(false);
                                                transform.position = RestartRun;               
                                                Leader.SetActive(false);
                                            }       
                                if(_hit.transform.tag == "RestartGame")
                                {
                                    transform.position = RestartGame;  
                                }    
                            
                        }    

         
               }
    }    
}