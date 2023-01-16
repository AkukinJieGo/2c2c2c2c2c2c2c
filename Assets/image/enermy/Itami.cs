using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Itami : MonoBehaviour
{
    float RRRCold=0.2f;
    float RRRTimer=0f;
    bool RRRBool=false;
    [SerializeField] private int damage;
    // Start is called before the first frame update
    void Start()
    {
        damage=5;
    }

    // Update is called once per frame
    void Update()
    {
         if(!RRRBool)
        {
            RRRTimer+=Time.deltaTime;
            if(RRRTimer>=RRRCold)
            {
                RRRBool=true;
                RRRTimer=0;
            }
        }   
    }
    private void OnTriggerEnter2D(Collider2D col) {
        if(col.gameObject.tag=="Player")
        {
            if(RRRBool)
            {
            GameObject.Find("Player").GetComponent<PlayerHealth>().TakeDamage(damage);
            RRRBool=false;
            }
        }
    }
}
