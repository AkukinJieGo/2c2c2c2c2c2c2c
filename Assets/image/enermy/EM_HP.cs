using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EM_HP : MonoBehaviour
{
    int hp=0;
    public int max_hp=0;
    public GameObject em_hp;
    public GameObject EM_hp_bar;
    // Start is called before the first frame update
    void Start()
    {
        max_hp = 100;
        hp = max_hp;
    }

    // Update is called once per frame
    void Update()
    {
        if(hp<=0)
        {
            Destroy(this.transform.parent.transform.parent.gameObject);
            Debug.Log("haha");
        }
        float _percent = ((float)hp/(float)max_hp);
        em_hp.transform.localScale = new Vector3 (_percent,em_hp.transform.localScale.y,em_hp.transform.localScale.z);
    }
    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "FireBall")
        {
            hp-=20;
            Debug.Log("阿");
        }
    }
    public void dl()
    {
        hp=0;
    }
    
}