using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class D07_Light_Switch_Controller : MonoBehaviour
{
    int state;
    public GameObject LampOn, LampOff;
    private void Start()
    {
        state = 0;
        LampOn.SetActive(false);
        LampOff.SetActive(true);
    }
    private void OnMouseDown()
    {
        state = 1 - state;
        if (state == 0)
        {
            LampOn.SetActive(false);
            LampOff.SetActive(true);
            print("Lamp On");
        }
        else if (state == 1)
        {
            LampOn.SetActive(true);
            LampOff.SetActive(false);
            print("Lamp Off");
        }
    }
}