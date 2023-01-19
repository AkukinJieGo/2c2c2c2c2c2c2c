using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    //動畫
    public Animator anim;
    float attackanimcold=0.0945f;
    float attackanimTimer=0f;
    bool attackanimBoll=true;

    //重生點
    private Vector3 spawnpoint;


    public Canvas Canvas_Pause;
    public Canvas Canvas_HUD;
    float Pausecold=0.3f;
    float PausecoldTimer=0f;
    bool PausecoldBoll=false;
    bool isPause=false;
    public LayerMask ground;
    float FireBallCooltime=1f;
    float FireBallTimer=0;
    bool TimeFireBall=false;
    public GameObject FireBallPerfab;
    [SerializeField] float moveSpeed=2;
    [SerializeField] float jumpforce=300;
    [SerializeField] private Rigidbody2D rigid2D;
    [SerializeField] private Collider2D Coll;
    [SerializeField] private Collider2D foot;



    public bool isjumping; 
    public bool isClimbing;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("開始");
        rigid2D = GetComponent<Rigidbody2D>();
        Coll = GetComponent<CapsuleCollider2D>();
        foot = GetComponent<BoxCollider2D>();
        Canvas_Pause.enabled=false;
        Canvas_HUD.enabled=true;
        this.transform.position=spawn.spawnpoint;
    }
    void Update()
    {
        if(!attackanimBoll)
        {
            attackanimTimer+=Time.deltaTime;

            if(attackanimTimer>=attackanimcold)
            {
                anim.SetFloat("attacking",Mathf.Abs(0));
                attackanimBoll=true;
                attackanimTimer=0;
            }
        }
        switch(Time.timeScale)
        {
            case 1 :
            isPause=false;
            break;
            case 0 :
            isPause=true;
            break;
        }
        if(!PausecoldBoll)
        {
            PausecoldTimer+=Time.deltaTime;
            if(PausecoldTimer>=Pausecold)
            {
                PausecoldBoll=true;
                PausecoldTimer=0;
            }
        }
        if(Input.GetKeyDown(KeyCode.P))
        {
            //暫停
            if(PausecoldBoll)
            {
                if(!isPause)
                {
                    pausetime();
                }
            }
        }
    }
    void FixedUpdate()
    {
        if(!TimeFireBall)
        {
            FireBallTimer+=Time.deltaTime;
            if(FireBallTimer>=FireBallCooltime)
            {
                TimeFireBall=true;
                FireBallTimer=0;
            }
        }
        if(PlayerHealth.health!=0)
        {
            move();
        }
    }
    void move()
    {
        float facedircetion = Input.GetAxisRaw("Horizontal");
        if(!Input.GetKey(KeyCode.D)&&!Input.GetKey(KeyCode.A))
        {
            anim.SetFloat("running",Mathf.Abs(facedircetion));
        }
        if(Input.GetKey(KeyCode.D))
        {
            Debug.Log("向右");
            transform.Translate(moveSpeed*Time.deltaTime,0,0);
            transform.localScale = new Vector3(1,1,1);
            anim.SetFloat("running",Mathf.Abs(facedircetion));
        }
        if(Input.GetKey(KeyCode.A))
        {
            Debug.Log("向左");
            transform.Translate(-moveSpeed*Time.deltaTime,0,0);
            transform.localScale = new Vector3(-1,1,1);
            anim.SetFloat("running",Mathf.Abs(facedircetion));
        }
        if(Input.GetKey(KeyCode.W)&&foot.IsTouchingLayers(ground)||Input.GetKey(KeyCode.Space)&&foot.IsTouchingLayers(ground))
        {
            Debug.Log("跳躍");
            rigid2D.velocity = new Vector2(rigid2D.velocity.x,jumpforce*Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.J))
        {
            if(TimeFireBall)
            {
            Debug.Log("攻擊");
            anim.SetFloat("attacking",Mathf.Abs(1));
            Instantiate(FireBallPerfab,this.transform.position,Quaternion.identity);
            TimeFireBall=false;
            attackanimBoll=false;
            }
        }
        if(Input.GetKey(KeyCode.R))
        {
            Debug.Log("重來");
            SceneManager.LoadScene(1);  
        }
    }
    void pausetime()
    {
        Time.timeScale=0;
        isPause=true;
        Canvas_Pause.enabled=true;
        Canvas_HUD.enabled=false;
    }
    private void OnTriggerEnter2D(Collider2D col) {
        if(col.gameObject.tag=="Spawnpoint")
        {
            spawn.spawnpoint=col.transform.position;
        }
    }
}
