using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Text healthtext;
    public static int HealthCurrent;
    public static int Healthmax;

    private Image healthbar;
    void Start()
    {
        healthbar = GetComponent<Image>();
        HealthCurrent = Healthmax;
    }

    // Update is called once per frame
    void Update()
    {
        healthbar.fillAmount=(float)HealthCurrent/(float)Healthmax;
        healthtext.text=HealthCurrent.ToString()+"/"+Healthmax.ToString();
    }
}
