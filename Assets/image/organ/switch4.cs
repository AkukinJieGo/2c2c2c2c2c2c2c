using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switch4 : MonoBehaviour
{
    public bool OnOrOff;
    public GameObject floor1;
    public GameObject floor2;
    //動畫
    public Animator anim;
    

    //計時
    bool ontime=true;
    float ontimer=0;
    float ontimercold=1f;
    // Start is called before the first frame update
    void Start()
    {
        floor1.SetActive(false);
        floor2.SetActive(false);
        anim.SetFloat("switch",0);
        OnOrOff=false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!ontime)
        {
            ontimer+=Time.deltaTime;
            if(ontimer>=ontimercold)
            {
                ontime=true;
                ontimer=0;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D col) {
        if(col.gameObject.tag=="Player")
        {
            if(ontime)
            {
                if(!OnOrOff)
                {
                    floor1.SetActive(true);
                    floor2.SetActive(true);
                    anim.SetFloat("switch",1);
                    OnOrOff=true;
                    ontime=false;
                }
                else if(OnOrOff)
                {
                    floor1.SetActive(false);
                    floor2.SetActive(false);
                    anim.SetFloat("switch",0);
                    OnOrOff=false;
                    ontime=false;
                }
            }
            
            
        }
    }
}