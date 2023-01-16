using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class enermy : MonoBehaviour
{
    private PlayerHealth playerHealth;
    public enum Status{ idle, walk};
    public Status status;
    public enum Face {Right,Left};
    public Face face;
 
    public float searchroundsize=6f;
    public float speed = 5;//可改
    private Transform myTransform;
 
    public Transform playerTransform;
    private SpriteRenderer spr;
    void Start()
    {
        playerHealth=GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        spr = this.transform.GetComponent<SpriteRenderer>();
        if(spr.flipX){
            face = Face.Right;
        }else{
            face = Face.Left;
        }
        myTransform = this.transform;
        if(GameObject.Find("Player") != null){
            playerTransform = GameObject.Find("Player").transform;//拿到Player名字的transform(可改)
        }
    }
 
    void FixedUpdate()
    {
        float deltaTime = Time.deltaTime;
        //updata Status action
        switch (status){
            case Status.idle:
                if (playerTransform){
                    if(Mathf.Abs(myTransform.position.x - playerTransform.position.x )< searchroundsize){ //怪物攻擊範圍
                            status = Status.walk;
                    }
                }
                break;
            case Status walk:
                if(playerTransform){
                    if(myTransform.position.x >= playerTransform.position.x){
                        if(Mathf.Abs(myTransform.position.y - playerTransform.position.y )< 1f){
                        spr.flipX = false;
                        face = Face.Left;
                        }
                    }else{
                        if(Mathf.Abs(myTransform.position.y - playerTransform.position.y )< 1f){
                        spr.flipX = true;
                        face = Face.Right;
                        }
                    }
 
                    if (playerTransform){
                        if(Mathf.Abs(myTransform.position.x - playerTransform.position.x )> 6f){ //怪物換成等待狀態
                            status = Status.idle;
                        }
                    }
                }
                switch (face){
 
                    case Face.Right:
                        myTransform.position += new Vector3(speed * deltaTime,0,0);//怪物的移動(可改)
                        break;
                    case Face.Left:
                        myTransform.position -= new Vector3(speed * deltaTime,0,0);
                        break;
                }
                break;
 
        }
    }

}
