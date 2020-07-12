using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Moving : MonoBehaviour
{
    private float moveForce = 70f; // tốc độ chạy
    private float jumpForce = 300f; // độ cao nhảy
    private float maxVelocity = 2f; // vận tốc
    public static bool isPhysicAttack = false;
    public bool grounded;
    public static float maxHealth;
    public static float health;
    public static int physicDmg;
    public static int armor;
    public static int magicDmg;
    public static int magicLevel;
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
    public static bool isDie;

    public GameObject floatDamge;
    public Sprite lv1Imgskill;
    public Sprite lv2Imgskill;
    public Sprite lv3Imgskill;
    public Sprite lv4Imgskill;

    // item 
    //
    void Awake(){
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        magicDmg = MainMenuController.MagicDmg;
        magicLevel = MainMenuController.MagicLevel;
        physicDmg = MainMenuController.PhysicDmg;
        maxHealth = MainMenuController.Health;
        health= maxHealth;
        isDie = false;
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
        if(magicLevel == 0){
            _magicalButton.GetComponent<Image>().sprite = lv1Imgskill;
            _magicSkill.GetComponent<Image>().sprite = lv1Imgskill;
            cooldown = 10;
        }
        else if(magicLevel == 1){
            _magicalButton.GetComponent<Image>().sprite = lv2Imgskill;
            _magicSkill.GetComponent<Image>().sprite = lv2Imgskill;
            cooldown = 8;
        }
        else if(magicLevel == 2){
           _magicalButton.GetComponent<Image>().sprite = lv3Imgskill;
            _magicSkill.GetComponent<Image>().sprite = lv3Imgskill;
            cooldown = 5;
        }
        else{
            _magicalButton.GetComponent<Image>().sprite = lv4Imgskill;
            _magicSkill.GetComponent<Image>().sprite = lv4Imgskill;
            cooldown = 3;
        }
    }
    void PhysicalButtonOnclick()
    {
        if(anim.GetBool("isMagicalAttack")==false){
                //StartCoroutine("TrueAttack");
            isPhysicAttack=true;
            anim.SetBool("isPhysicalAttack",true);
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
        // maxHealth=MainMenuController.Health;
        physicDmg =MoneyCounter.tmpPhysicDmg;
        armor = MoneyCounter.tmpArmor;
        // if not die----------------------------------
        if(anim.GetBool("isDie")==false){
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
            /// draw health bar
            healthAmount.fillAmount = health/maxHealth;
            healthText.text = health + "/" + maxHealth;

            // cooldown skill
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
    
        // if Die

        if(health<=0){
            health = 0;
            anim.SetBool("isDie",true);
            isDie = true;
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
                // MainMenuController.Money+=10;
                
                // MainMenuController.level2=true;
                // MainMenuController.SaveData();
 // ------------------------------------------- End test -------------------------
            }
        }
        else{

        }
        if(Input.GetKey (KeyCode.Return)){
            if(anim.GetBool("Jump")==true){
                
            }
            else{
                if(anim.GetBool("isMagicalAttack")==false){
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
        if((target.gameObject.tag=="Gobin" || target.gameObject.tag=="Orc" || target.gameObject.tag=="Orge" ||  target.gameObject.tag=="Golem1" || target.gameObject.tag== "Golem2"
    ||  target.gameObject.tag=="Golem3" ||  target.gameObject.tag=="ReaperMan1" ||  target.gameObject.tag=="ReaperMan2" ||  target.gameObject.tag=="ReaperMan3" ||
     target.gameObject.tag=="1_TROLL" ||  target.gameObject.tag=="2_TROLL" || target.gameObject.tag=="3_TROLL" ||  target.gameObject.tag=="Elf" ||  target.gameObject.tag=="Fairy") && target.gameObject.layer==10)
        {
            anim.SetTrigger("isHurt");
             //check level curent và get Enemy damge
            Scene m_Scene;
            m_Scene = SceneManager.GetActiveScene();
            string currentlv = m_Scene.name.Substring(5);
            float enemyDmg=0;
            string enemyDmgTxt="";
            if(currentlv=="1"){
                if(target.gameObject.tag=="Gobin"){
                    enemyDmg=10f;
                }
                else if(target.gameObject.tag=="Orc"){
                    enemyDmg=8f;
                }
                else if(target.gameObject.tag=="Orge"){
                    enemyDmg=15f;
                }
                else if(target.gameObject.tag=="Golem3"){
                    enemyDmg=5f;
                }
                else if(target.gameObject.tag=="1_TROLL"){
                    enemyDmg=20f;
                }
            }
            else if(currentlv =="2"){
                if(target.gameObject.tag=="Gobin"){
                    enemyDmg=12f;
                }
                else if(target.gameObject.tag=="Orc"){
                    enemyDmg=10f;
                }
                else if(target.gameObject.tag=="Orge"){
                    enemyDmg=20f;
                }
                else if(target.gameObject.tag=="Golem3"){
                    enemyDmg=10f;
                }
                else if(target.gameObject.tag=="2_TROLL"){
                    enemyDmg=35f;
                }
                else if(target.gameObject.tag=="ReaperMan1"){
                    enemyDmg=30f;
                }
                
            }
            else if(currentlv == "3"){

                if(target.gameObject.tag=="Gobin"){
                    enemyDmg=20f;
                }
                else if(target.gameObject.tag=="Orc"){
                    enemyDmg=15f;
                }
                else if(target.gameObject.tag=="Orge"){
                    enemyDmg=25f;
                }
                else if(target.gameObject.tag=="Golem1"){
                    enemyDmg=20f;
                }
                else if(target.gameObject.tag=="Golem2"){
                    enemyDmg=15f;
                }
                else if(target.gameObject.tag=="Golem3"){
                    enemyDmg=10f;
                }
                else if(target.gameObject.tag=="3_TROLL"){
                    enemyDmg=60f;
                }
                else if(target.gameObject.tag=="ReaperMan1"){
                    enemyDmg=40f;
                }
                else if(target.gameObject.tag=="ReaperMan2"){
                    enemyDmg=50f;
                }

            }
            else if(currentlv == "4"){

                
                if(target.gameObject.tag=="Gobin"){
                    enemyDmg=25f;
                }
                else if(target.gameObject.tag=="Orc"){
                    enemyDmg=20f;
                }
                else if(target.gameObject.tag=="Orge"){
                    enemyDmg=30f;
                }
                else if(target.gameObject.tag=="Golem1"){
                    enemyDmg=20f;
                }
                else if(target.gameObject.tag=="Golem2"){
                    enemyDmg=25f;
                }
                else if(target.gameObject.tag=="Golem3"){
                    enemyDmg=20f;
                }
                else if(target.gameObject.tag=="ReaperMan1"){
                    enemyDmg=70f;
                }
                else if(target.gameObject.tag=="ReaperMan2"){
                    enemyDmg=75f;
                }
                else if(target.gameObject.tag=="ReaperMan2"){
                    enemyDmg=80f;
                }
                else if(target.gameObject.tag=="Elf"){
                    enemyDmg=100f;
                }

            }
            else if(currentlv=="5"){

                 if(target.gameObject.tag=="Gobin"){
                    enemyDmg=30f;
                }
                else if(target.gameObject.tag=="Orc"){
                    enemyDmg=25f;
                }
                else if(target.gameObject.tag=="Orge"){
                    enemyDmg=40f;
                }
                else if(target.gameObject.tag=="Golem1"){
                    enemyDmg=50f;
                }
                else if(target.gameObject.tag=="Golem2"){
                    enemyDmg=45f;
                }
                else if(target.gameObject.tag=="Golem3"){
                    enemyDmg=40f;
                }
                else if(target.gameObject.tag=="ReaperMan1"){
                    enemyDmg=90f;
                }
                else if(target.gameObject.tag=="ReaperMan2"){
                    enemyDmg=95f;
                }
                else if(target.gameObject.tag=="ReaperMan2"){
                    enemyDmg=100f;
                }
                else if(target.gameObject.tag=="Fairy"){
                    enemyDmg=150f;
                }

            }
            else{ // for level test
                if(target.gameObject.tag=="Gobin"){
                    enemyDmg=1f;
                }
                else if(target.gameObject.tag=="Orc"){
                    enemyDmg=1f;
                }
                else if(target.gameObject.tag=="Orge"){
                    enemyDmg=1f;
                }
                else if(target.gameObject.tag=="Golem1"){
                    enemyDmg=1f;
                }
                else if(target.gameObject.tag=="Golem2"){
                    enemyDmg=1f;
                }
                else if(target.gameObject.tag=="Golem3"){
                    enemyDmg=1f;
                }
                else if(target.gameObject.tag=="ReaperMan1"){
                    enemyDmg=90f;
                }
                else if(target.gameObject.tag=="ReaperMan2"){
                    enemyDmg=95f;
                }
                else if(target.gameObject.tag=="ReaperMan2"){
                    enemyDmg=100f;
                }
                else if(target.gameObject.tag=="Fairy"){
                    enemyDmg=150f;
                }
            }

            Debug.Log(currentlv);

            float subtractDmg=0;
            subtractDmg =  enemyDmg - (enemyDmg*armor/10)/100<0?0:enemyDmg - (enemyDmg*armor/10)/100;


            health=(health - subtractDmg)<0? 0 : (health - subtractDmg);
            GameObject damgeShow = Instantiate(floatDamge,transform.position, Quaternion.identity) as GameObject;
            damgeShow.transform.GetChild(0).GetComponent<TextMesh>().text =  "-" + subtractDmg.ToString();
            Destroy(damgeShow, 1f);

             // xử lý bị đánh ko đánh lại và bị văng ra
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
            GameObject clone =Instantiate(bullet, new Vector2(transform.position.x+1f,transform.position.y), Quaternion.Euler(new Vector3(0, 0, 0 ))) as GameObject;
            Vector3 scale = bullet.transform.localScale;
             if(magicLevel == 0 || magicLevel== 1 || magicLevel ==2){
                scale.x = 2;
                scale.y= 2;
             }
            // else if(magicLevel == 2){
            //     scale.x=3;
            //     scale.y = 3;

            //  }
             else{
                scale.x=1;
                scale.y = 1;
             }
             clone.transform.localScale = scale;
         }
         else{
            GameObject clone =Instantiate(bullet, new Vector2(transform.position.x-1f,transform.position.y), Quaternion.Euler(new Vector3(0, 0, 0 ))) as GameObject;
            Vector3 scale = bullet.transform.localScale;
             Debug.Log(magicLevel);
             if(magicLevel == 0 || magicLevel == 1 || magicLevel==2){
                scale.x = -2;
                scale.y= 2;
             }
            //  else if(magicLevel == 2){
            //     scale.x=-2;
            //     scale.y = 3;

            //  }
             else{
                scale.x=-1;
                scale.y = 1;
             }
             clone.transform.localScale = scale;
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