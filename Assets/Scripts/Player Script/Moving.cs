using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Moving : MonoBehaviour
{
    private float moveForce = 70f; // tốc độ chạy
    private float jumpForce = 300f; // độ cao nhảy
    private float maxVelocity = 2f; // vận tốc
    public static bool isPhysicAttack = false;
    public bool grounded;
    private float maxHealth;
    public float health;

    public static int physicDmg;
    public static int magicDmg;
    private Rigidbody2D myBody;
    private Animator anim;
    // private bool shotable=true;
    public float minX,maxX;
    public Transform player;


    [SerializeField]
    public GameObject bullet;
    [SerializeField]
    public Image healthAmount;
    public Text healthText;
    
    public Button PHYSICATTACK;
    public Button MAGICALATTACK;
    public Button JUMP;
    public Button MOVELEFT;
    public Button MOVERIGHT;
    private Button _physicalButton;
    private Button _magicalButton;
    public Image _magicSkill;
    // [SerializeField]
    private float cooldown=10;
    bool isCooldown;
    public Text cooldownText;
    private Button _jumpButton;
    private Button _moveLeftButton;
    private Button _moveRightButton;
    void Awake(){
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        magicDmg = MainMenuController.MagicDmg;
        physicDmg = MainMenuController.PhysicDmg;
        maxHealth = MainMenuController.Health;
        health= maxHealth;
    }
    float count;
    // Start is called before the first frame update
    void Start()
    {
        _physicalButton = PHYSICATTACK.GetComponent<Button>();
        _magicalButton = MAGICALATTACK.GetComponent<Button>();
        // _jumpButton = JUMP.GetComponent<Button>();
        // _moveLeftButton = MOVELEFT.GetComponent<Button>();
        // _moveRightButton = MOVERIGHT.GetComponent<Button>();

        _physicalButton.onClick.AddListener(PhysicalButtonOnclick);
        _magicalButton.onClick.AddListener(MagicalButtonOnclick);
        // _moveLeftButton.onClick.AddListener(MoveLeftButtonOnclick);
        // _jumpButton.onClick.AddListener(JumpButtonOnclick);
        // _moveRightButton.onClick.AddListener(MoveRightButtonOnclick);
        
        player = GameObject.Find("Player").transform;
        count  = cooldown;
    }
    void PhysicalButtonOnclick()
    {
       if(anim.GetBool("Jump")==true){
                
            }
            else{
                if(anim.GetBool("isMagicalAttack")==false && grounded){
                     //StartCoroutine("TrueAttack");
                    isPhysicAttack=true;
                    anim.SetBool("isPhysicalAttack",true);
                }
            }
    }
    void MagicalButtonOnclick(){
        if(isCooldown==false){
            if(anim.GetBool("isPhysicalAttack")==false & grounded){
                anim.SetBool("isMagicalAttack",true);
                // BulletShow();
                                            StartCoroutine("BulletShow");
                //StartCoroutine("BulletShow2"); // item liên hoàn
                // Instantiate(bullet, transform.position, Quaternion.Euler(new Vector3(0, 0, 0 )));
                isCooldown = true;
                _magicSkill.fillAmount=1;
                _magicalButton.interactable=false;
            }
        }
    }
    // void JumpButtonOnclick(){
    //      Debug.Log ("jump");
    // }
    // void MoveRightButtonOnclick(){
    //      Debug.Log ("phai");
    // }
    // void MoveLeftButtonOnclick(){
    //      Debug.Log ("trai");
    // }

    // Update is called once per frame
    void FixedUpdate()
    {
        maxHealth=MainMenuController.Health;
        physicDmg =MainMenuController.PhysicDmg;
        magicDmg = MainMenuController.MagicDmg;
        MagicalAttack();
        if(anim.GetCurrentAnimatorStateInfo(0).IsName("PhysicalAttack") && // code sau khi hoàn thành đánh thường thì ko đánh lại lần nữa
            anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
            {
                anim.SetBool("isPhysicalAttack", false);
                isPhysicAttack=false;
            }
        if(anim.GetCurrentAnimatorStateInfo(0).IsName("MagicalAttack") &&  // code sau khi hoàn thành vận skill thì ko vận lại lần nữa
        anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {
            isPhysicAttack=false;
            anim.SetBool("isMagicalAttack", false);
        }

        if(anim.GetCurrentAnimatorStateInfo(0).IsName("MagicalAttack")){ // nếu đang vận skill magic thì ko cho di chuyển
            transform.position = transform.position;
        }
        else{
            PlayerMoveKeyboard();
        }
        healthAmount.fillAmount = health/maxHealth;
        healthText.text = health + "/" + maxHealth;
        if(isCooldown){
            _magicSkill.fillAmount -= 1/cooldown * Time.deltaTime;
            // float seconds = (_magicSkill.fillAmount % 60);
            // Debug.Log(seconds);

            // cooldownText.text = count.ToString();
            // count--;
            //Debug.Log( _magicSkill.fillAmount);
            if(_magicSkill.fillAmount<=0){
                isCooldown=false;
                _magicSkill.fillAmount=0;
                _magicalButton.interactable=true;
            }
        }
        
    }
    void PlayerMoveKeyboard(){
        float forceX = 0f;
        float forceY = 0f;
        float vel = Mathf.Abs(myBody.velocity.x);

        float h = Input.GetAxisRaw("Horizontal"); // -1 0 1
        if(h > 0){
            if(vel < maxVelocity){
                if(grounded==true){
                    forceX=moveForce;
                }
                else{
                    forceX = moveForce*1.1f;
                }
            }

            
            Vector3 scale = transform.localScale;
            scale.x = -0.58f;
            transform.localScale = scale;

            anim.SetBool("Walk",true);
        }
        else if(h < 0 ){
            if(vel < maxVelocity){
                if(grounded==true){
                    forceX=-moveForce;
                }
                else{
                    forceX = -moveForce*1.1f;
                }
            }
            
            Vector3 scale =transform.localScale;
            scale.x = 0.58f;
            transform.localScale = scale;

            anim.SetBool("Walk",true);
        }
        else if(h==0){
            anim.SetBool("Walk",false);
        }

        
        if(Input.GetKey (KeyCode.Space)){ // nhảy
            if(grounded){
                anim.SetTrigger("Jump");
                anim.SetBool("isPhysicalAttack", false);
                grounded =false;
                forceY= jumpForce;
                FindObjectOfType<AudioManager>().Play("jump");
  //-------------------------------------------  Test Save + money counter -----------------------
                MainMenuController.Money+=10;
                
                MainMenuController.level2=true;
                MainMenuController.SaveData();
 // ------------------------------------------- End test -------------------------
            }
        }
        else{

        }
        if(Input.GetKey (KeyCode.Return)){
            if(anim.GetBool("Jump")==true){
                
            }
            else{
                if(anim.GetBool("isMagicalAttack")==false && grounded){
                     //StartCoroutine("TrueAttack");
                    isPhysicAttack=true;
                    anim.SetBool("isPhysicalAttack",true);
                }
            }
        }

        myBody.AddForce( new Vector2(forceX,forceY)); // di chuyển

        //  limited move range
        Vector3 temp = transform.position;
                temp.x=player.position.x;
                if(temp.x < minX){
                    temp.x= minX;
                }
                else if (temp.x > maxX){
                    temp.x = maxX;
                }
                transform.position=temp;
    }   
    void OnCollisionEnter2D(Collision2D target){
        if(target.gameObject.tag =="Ground"){
            grounded = true;
        }
        if(target.gameObject.tag=="Enemy" && target.gameObject.layer==11)
        {
            health-=10f;
            anim.SetTrigger("isHurt");
            isPhysicAttack=false;
           Vector3 delta = target.transform.position - transform.position;
        // check side trigger
                if(delta.x < delta.y){
                     myBody.velocity = myBody.velocity + Vector2.right *5;
                }
                else{
                     myBody.velocity = myBody.velocity + Vector2.left *5;
                }

        }
    }

    void MagicalAttack(){ // bắn đạn

        if(Input.GetKey (KeyCode.L) && isCooldown==false){
            if(anim.GetBool("isPhysicalAttack")==false & grounded){
                anim.SetBool("isMagicalAttack",true);
                isCooldown = true;
                _magicSkill.fillAmount=1;
                _magicalButton.interactable=false;
                // BulletShow();
                                            StartCoroutine("BulletShow");
                //StartCoroutine("BulletShow2"); // item liên hoàn
                // Instantiate(bullet, transform.position, Quaternion.Euler(new Vector3(0, 0, 0 )));
            }
        }
    }
         private IEnumerator BulletShow() // hàm delay thời gian bắn đạn
     {        
         yield return new WaitForSeconds(0.75f);
         if(transform.localScale.x < 0){
            Instantiate(bullet, new Vector2(transform.position.x+1f,transform.position.y), Quaternion.Euler(new Vector3(0, 0, 0 )));
         }
         else{
            Instantiate(bullet, new Vector2(transform.position.x-1f,transform.position.y), Quaternion.Euler(new Vector3(0, 0, 0 )));
         }

     }
     private IEnumerator BulletShow2() // hàm delay thời gian bắn đạn
     {        
         yield return new WaitForSeconds(0.5f);
         if(transform.localScale.x < 0){
            Instantiate(bullet, new Vector2(transform.position.x+1f,transform.position.y), Quaternion.Euler(new Vector3(0, 0, 0 )));
         }
         else{
            Instantiate(bullet, new Vector2(transform.position.x-1f,transform.position.y), Quaternion.Euler(new Vector3(0, 0, 0 )));
         }

     }
}
