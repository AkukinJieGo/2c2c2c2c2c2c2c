using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack : MonoBehaviour
{
    float attackCold=0.2f;
    float attackTimer=0f;
    bool attackBool=false;
    [SerializeField] private Collider2D Enermycol;
    [SerializeField] private int damage;
    // Start is called before the first frame update
    void Start()
    {
        damage=5;
        Enermycol=GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!attackBool)
        {
            attackTimer+=Time.deltaTime;
            if(attackTimer>=attackCold)
            {
                attackBool=true;
                attackTimer=0;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D col) {
        if(col.gameObject.tag=="Player")
        {
            if(attackBool)
            {
            GameObject.Find("Player").GetComponent<PlayerHealth>().TakeDamage(damage);
            attackBool=false;
            }
        }
    }
}
