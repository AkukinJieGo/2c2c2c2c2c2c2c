using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpfloor : MonoBehaviour
{
    bool onfloor=false;
    bool down=false;
    private Transform myTransform;
    public Transform playerTransform;
    public GameObject floor1;
    [SerializeField] private Collider2D Coll;
    public float width; 

    // Start is called before the first frame update
    void Start()
    {
        width=this.transform.parent.GetComponent<SpriteRenderer>().bounds.size.x;
        myTransform = this.transform;
        if(GameObject.Find("Player") != null){
            playerTransform = GameObject.Find("Player").transform;//拿到Player名字的transform(可改)
        }
        Coll.enabled=false;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(width);
        if(Mathf.Abs(myTransform.position.x - playerTransform.position.x )<(width/1.5)&&playerTransform.position.y-myTransform.position.y>(0.8)&&playerTransform.position.y-myTransform.position.y<30f)
        {
            onfloor=true;
        }
        else
        {
            onfloor=false;
        }
        switch(onfloor)
        {
            case true:
                Coll.enabled=true;
                if(Input.GetKey(KeyCode.S))
                {
                Coll.enabled=false;
                }
            break;
            case false:
                Coll.enabled=false;
                break;
        }
    }
}
