using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall01 : MonoBehaviour
{
    [SerializeField] float moveSpeed=10;
    [SerializeField] float move=10;
    
    public Transform playerScale;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject,1f);
        if(GameObject.Find("Player") != null){
            playerScale = GameObject.Find("Player").transform;//拿到Player名字的transform(可改)
        }
        transform.localScale = new Vector3(transform.localScale.x*playerScale.localScale.x,transform.localScale.y,transform.localScale.z);
        Debug.Log(playerScale.localScale.x);
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.localScale.x<0)
        {
            transform.Translate(-moveSpeed*Time.deltaTime*move,0,0);
        }
        if(transform.localScale.x>0)
        {
            transform.Translate(moveSpeed*Time.deltaTime*move,0,0);
        }
    }
    private void OnTriggerEnter2D(Collider2D col) 
    {
    if(col.gameObject.tag=="wall")
        {
            Destroy(this.gameObject);
        }
    }
}
