using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClick : MonoBehaviour
{
    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
        if(Physics.Raycast (ray, out hit))
        {
            if(hit.collider.tag == ("Buttons"))
            {
                if (Input.GetKeyDown (KeyCode.Mouse0))
                {
                    Destroy (hit.collider.gameObject);
                }
            }
        }
    }
}
