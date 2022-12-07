using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButStart : MonoBehaviour
{
    public GameObject WallStart;
    public GameObject TimeHud;
    
    public void ButtonStart()
    {
        WallStart.SetActive(false);
        TimeHud.SetActive(true);
    }
}
