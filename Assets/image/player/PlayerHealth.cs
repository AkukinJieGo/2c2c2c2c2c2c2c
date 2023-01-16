using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    static public int health=20;
    [SerializeField]bool TimeDamage=false;
    float DamageCooltime=0.5f;

    float DamageTimer=0;
    [SerializeField] public Collider2D boxcoll;
    public Image ImageHealth;
    void Start()
    {
        health=20;
        HealthBar.Healthmax=health;
        HealthBar.HealthCurrent=health;
        boxcoll = GetComponent<CapsuleCollider2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(!TimeDamage)
        {
            DamageTimer+=Time.deltaTime;
            if(DamageTimer>=DamageCooltime)
            {
                TimeDamage=true;
                DamageTimer=0;
            }
        }
        if(health==0)
        {
            SceneManager.LoadScene(2);
        }
        
    }

    public void TakeDamage(int damage)
    {
        //if(TimeDamage)
        //{
            health -= damage;
            if(health<0)
            {
                health=0;
            }
            HealthBar.HealthCurrent=health;
            //TimeDamage=false;
        //}
    }
    public void Healing(int damage)
    {
        health += damage;
        if(health>=HealthBar.Healthmax)
        {
            health=HealthBar.Healthmax;
        }
        HealthBar.HealthCurrent=health;
    }
    public void deadline()
    {
        health=0;
        HealthBar.HealthCurrent=health;
    }
}
