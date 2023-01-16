using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stop01 : MonoBehaviour
{
    public Canvas Canvas_Pause;
    public Canvas Canvas_HUD;
    bool isPause=false;
    // Start is called before the first frame update
    void Start()
    {
        isPause=false;
    }

    // Update is called once per frame
    void Update()
    {
        switch(Time.timeScale)
        {
            case 1 :
            isPause=false;
            break;
            case 0 :
            isPause=true;
            break;
        }
    }
    public void continuestart()
    {
        Time.timeScale=1;
        isPause=false;
        Canvas_Pause.enabled=false;
        Canvas_HUD.enabled=true;
    }
}
