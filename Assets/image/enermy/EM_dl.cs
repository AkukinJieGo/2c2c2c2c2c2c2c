using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EM_dl : MonoBehaviour
{
    [SerializeField] public Collider2D boxcoll;
    // Start is called before the first frame update
    void Start()
    {
        boxcoll = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D col) {
        if(col.gameObject.tag=="deadline")
        {
            GameObject.Find(this.transform.parent.gameObject.name).GetComponent<EM_HP>().dl();
        }
        else
        {
            Debug.Log("hh");
        }
    }
}
