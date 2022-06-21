using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    //functions to be hookedup to UI butons
    //Also could be called when a random event message pops up
   public void TimePause()
    {
        Time.timeScale = 0;
    }
    public void TimeNormal()
    {
        Time.timeScale = 1;
    }
    public void TimeSpeedUp()
    {
        Time.timeScale = 2;
    }
}
