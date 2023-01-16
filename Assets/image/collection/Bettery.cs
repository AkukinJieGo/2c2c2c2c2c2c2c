using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bettery : MonoBehaviour
{
    [SerializeField] private Collider2D battery;
    // Start is called before the first frame update
    void Start()
    {
        battery = GetComponent<PolygonCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D col) {
        if(col.gameObject.tag=="Player")
        {
            print(col.gameObject.name);
            GameObject.Find("Player").GetComponent<PlayerHealth>().Healing(5);
            Destroy(this.gameObject);
        }
    }
}
