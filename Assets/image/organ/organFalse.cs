using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class organFalse : MonoBehaviour
{
    public GameObject floor1;
    public GameObject box1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D col) {
        if(col.gameObject.tag=="Player")
        {
            floor1.SetActive(false);
            Destroy(box1);
        }
    }
}
