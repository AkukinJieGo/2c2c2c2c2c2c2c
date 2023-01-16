using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class organTrue : MonoBehaviour
{
    public GameObject floor1;
    public GameObject floor2;
    public GameObject floor3;
    public GameObject floor4;
    public GameObject floor5;
    // Start is called before the first frame update
    void Start()
    {
        floor1.SetActive(false);
        floor2.SetActive(false);
        floor3.SetActive(false);
        floor4.SetActive(false);
        floor5.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D col) {
        if(col.gameObject.tag=="Player")
        {
            floor1.SetActive(true);
            floor2.SetActive(true);
            floor3.SetActive(true);
            floor4.SetActive(true);
            floor5.SetActive(true);
        }
    }
}
