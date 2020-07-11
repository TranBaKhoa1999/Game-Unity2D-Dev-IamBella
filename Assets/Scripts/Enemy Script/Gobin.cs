using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Gobin : MonoBehaviour
{
    [SerializeField]
    private Transform starPos,endPos;
     [SerializeField]
    private Transform playerpos;
    private bool collision; // bắt va chạm
    private float speed;
    private Rigidbody2D myBody;
    private Animator anim;
    private float hp;
    //[SerializeField]
    private float maxHp;
    private int cost = 0;

    public GameObject healthBar;
    public GameObject floatDamgePhysic;
    public GameObject floatDamgeMagic;
    private Transform player;

    private Vector2 movement;
    private float speedFollow;
    // Start is called before the first frame update
    void Awake() {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        player = GameObject.Find("Player").transform;
    }
    void Start()
    {
        Scene m_Scene;
        m_Scene = SceneManager.GetActiveScene();
        Time.timeScale=1f;
        string currentlv = m_Scene.name.Substring(5);
        int crlv;
        int.TryParse(m_Scene.name, out crlv);
        if(crlv ==1){
            if(gameObject.tag=="Gobin"){
                maxHp = 100;
                speed= 3f;
                cost = 10;
            }
            else if(gameObject.tag=="Orc"){
                maxHp = 150;
                speed= 3f;
                cost = 10;
            }
            else if(gameObject.tag=="Orge"){
                maxHp =70;
                speed= 3f;
                cost = 10;
            }
            if(gameObject.tag=="Golem3"){
                maxHp =500;
                speed =2f;
                cost = 20;
            }
            if(gameObject.tag=="1_TROLL"){
                maxHp =2000;
                speed = 2f;
                cost = 100;
            }

        }
        else if(crlv ==2){
            if(gameObject.tag=="Gobin"){
                maxHp = 200;
                speed= 3f;
                cost = 20;
            }
            else if(gameObject.tag=="Orc"){
                maxHp = 300;
                speed= 3f;
                cost = 20;
            }
            else if(gameObject.tag=="Orge"){
                maxHp =150;
                speed= 3f;
                cost = 20;
            }
            if(gameObject.tag=="Golem3"){
                maxHp =1000;
                speed =2f;
                cost = 30;
            }
            if(gameObject.tag=="ReaperMan1"){
                maxHp =100;
                speed =5f;
                cost = 30;
            }
            if(gameObject.tag=="2_TROLL"){
                maxHp =5000;
                speed = 2f;
                cost = 200;
            }
            
        }
        else if(crlv ==3){
            if(gameObject.tag=="Gobin"){
                maxHp = 400;
                speed= 3f;
                cost = 30;
            }
            else if(gameObject.tag=="Orc"){
                maxHp = 800;
                speed= 3f;
                cost = 30;
            }
            else if(gameObject.tag=="Orge"){
                maxHp =250;
                speed= 3f;
                cost = 30;
            }
            if(gameObject.tag=="Golem1"){
                maxHp =1500;
                speed =2f;
                cost = 40;
            }
            if(gameObject.tag=="Golem2"){
                maxHp =1700;
                speed =2f;
                cost = 40;
            }
            if(gameObject.tag=="Golem3"){
                maxHp =2000;
                speed =2f;
                cost = 40;
            }
            if(gameObject.tag=="ReaperMan1"){
                maxHp =300;
                speed =5f;
                cost = 40;
            }
            if(gameObject.tag=="ReaperMan1"){
                maxHp =250;
                speed =5f;
                cost = 40;
            }
            if(gameObject.tag=="3_TROLL"){
                maxHp =10000;
                speed = 2f;
                cost = 500;
            }
            
        }
        else if(crlv ==4){
            if(gameObject.tag=="Gobin"){
                maxHp = 500;
                speed= 3f;
                cost = 40;
            }
            else if(gameObject.tag=="Orc"){
                maxHp = 1000;
                speed= 3f;
                cost = 40;
            }
            else if(gameObject.tag=="Orge"){
                maxHp =300;
                speed= 3f;
                cost = 40;
            }
            if(gameObject.tag=="Golem1"){
                maxHp =3000;
                speed =2f;
                cost = 50;
            }
            if(gameObject.tag=="Golem2"){
                maxHp =3500;
                speed =2f;
                cost = 50;
            }
            if(gameObject.tag=="Golem3"){
                maxHp =4000;
                speed =2f;
                cost = 50;
            }
            if(gameObject.tag=="ReaperMan1"){
                maxHp =400;
                speed =5f;
                cost = 50;
            }
            if(gameObject.tag=="ReaperMan2"){
                maxHp =350;
                speed =5f;
                cost = 50;
            }
            if(gameObject.tag=="ReaperMan3"){
                maxHp =300;
                speed =5f;
                cost = 50;
            }
            if(gameObject.tag=="Elf"){
                maxHp =15000;
                speed = 2f;
                cost = 1000;
            }
            
        }
        else if(crlv ==5){
            if(gameObject.tag=="Gobin"){
                maxHp = 600;
                speed= 3f;
                cost = 50;
            }
            else if(gameObject.tag=="Orc"){
                maxHp = 1000;
                speed= 3f;
                cost = 50;
            }
            else if(gameObject.tag=="Orge"){
                maxHp =400;
                speed= 3f;
                cost = 50;
            }
            if(gameObject.tag=="Golem1"){
                maxHp =5000;
                speed =2f;
                cost = 60;
            }
            if(gameObject.tag=="Golem2"){
                maxHp =6000;
                speed =2f;
                cost = 60;
            }
            if(gameObject.tag=="Golem3"){
                maxHp =8000;
                speed =2f;
                cost = 60;
            }
            if(gameObject.tag=="ReaperMan1"){
                maxHp =500;
                speed =5f;
                cost = 60;
            }
            if(gameObject.tag=="ReaperMan2"){
                maxHp =450;
                speed =5f;
                cost = 60;
            }
            if(gameObject.tag=="ReaperMan3"){
                maxHp =400;
                speed =5f;
                cost = 60;
            }
            if(gameObject.tag=="Fairy"){
                maxHp =20000;
                speed = 2f;
                cost = 3000;
            }
        }
        else { // for level test
            if(gameObject.tag=="Gobin"){
                maxHp = 100;
                speed= 3f;
            }
            else if(gameObject.tag=="Orc"){
                maxHp = 150;
                speed= 3f;
            }
            else if(gameObject.tag=="Orge"){
                maxHp =70;
                speed= 3f;
            }
            if(gameObject.tag=="Golem3"){
                maxHp =500;
                speed =2f;
            }
            if(gameObject.tag=="1_TROLL"){
                maxHp =2000;
                speed = 2f;
            }
            speedFollow = 2;
        }
        hp = maxHp;
            
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(hp<=0){
            anim.SetBool("isDie",true);
             gameObject.layer=LayerMask.NameToLayer("notAttack");
                speed=0;
                speedFollow = 0;
                MainMenuController.Money+=cost;   
                MainMenuController.SaveData();
            // Destroy(gameObject);
        }
        collision = Physics2D.Linecast(starPos.position , endPos.position , 1 << LayerMask.NameToLayer("EnemyMoveRange"));
        bool colplayer;
        colplayer = Physics2D.Linecast(player.position, playerpos.position, 1 << LayerMask.NameToLayer("EnemyMoveRange"));
        if(collision && colplayer){  
            if(!collision || hp<=0){
                speedFollow=0;
            }
            else{
                speedFollow =2;
            }
            Vector3 dir = player.position - transform.position;
            dir.Normalize();
            movement = dir;
            AutoMove(movement);
            if(transform.localScale.x < 0){ // quái đi qua trái

                if(dir.x < dir.y){ // cùng side
                }
                else{ // khác side -> quay mặt
                    Vector3 temp = transform.localScale;
                    temp.x = temp.x * -1;
                    transform.localScale = temp;
                }
            }
            else{ // quái đi qua phải
                if(dir.x>dir.y){ // cùng side
                }
                else{// khác side -> quay mặt
                    Vector3 temp = transform.localScale;
                    temp.x = temp.x * -1;
                    transform.localScale = temp;
                }
            }
        }
            Move();
            Changedirection();

        bool x = anim.GetBool("isDie");
        if(anim.GetCurrentAnimatorStateInfo(0).IsName("Die") && anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.9f){
            Destroy(gameObject);
        }
         //Debug.Log(anim.GetBool("isDie"));
            //Move();
            
    }
    void Move(){
            myBody.velocity = new Vector2(transform.localScale.x, 0) * speed;

    }
    void AutoMove(Vector2 dir){

        myBody.MovePosition( (Vector2)transform.position + (new Vector2(dir.x,0) * speedFollow * Time.deltaTime));
        
    }
    // void OnTriggerStay2D(Collider2D target) {
    //     if(target.tag=="Player"){
    //         OnTriggerEnter2D(target);
    //     }
    // }
     void OnTriggerEnter2D(Collider2D target) {
        if(target.tag == "Player"){
            Debug.Log("cham");
            Vector3 delta = target.transform.position - transform.position;
        // check side trigger
            if(transform.localScale.x < 0){ // quái đi qua trái
                if(delta.x < delta.y){
                    gameObject.layer=LayerMask.NameToLayer("Attack");
                    anim.SetBool("Attack",true);
                }
                // else{
                //     gameObject.layer=LayerMask.NameToLayer("notAttack");
                // }
            }
            else{ // quái đi qua phải
                if(delta.x>delta.y){
                    gameObject.layer=LayerMask.NameToLayer("Attack");
                    anim.SetBool("Attack",true);
                }
                // else{
                //     gameObject.layer=LayerMask.NameToLayer("notAttack");
                // }
            }

            //Debug.Log(Moving.isAttack);
            if(Moving.isPhysicAttack==true){ // bị đánh thường
                anim.SetTrigger("hurt");
                gameObject.layer=LayerMask.NameToLayer("notAttack");
                hp-=Moving.physicDmg;

                // floating physic dmage
                GameObject damgeShow = Instantiate(floatDamgePhysic,transform.position, Quaternion.identity) as GameObject;
                damgeShow.transform.GetChild(0).GetComponent<TextMesh>().text =  "-" + Moving.physicDmg.ToString();
                 Destroy(damgeShow, 1f);

                healthBar.transform.localScale = new Vector3(hp>0?hp/maxHp:0,healthBar.transform.localScale.y,healthBar.transform.localScale.z);
            }
        }
        else{
            if(target.tag=="Bullet"){ // bị bắn
                hp -=Moving.magicDmg;

                //float ting magic damge
                GameObject damgeShow = Instantiate(floatDamgeMagic,transform.position, Quaternion.identity) as GameObject;
                damgeShow.transform.GetChild(0).GetComponent<TextMesh>().text = "-"+ Moving.magicDmg.ToString();
                Destroy(damgeShow, 1f);
    
                anim.SetTrigger("hurt");
                gameObject.layer=LayerMask.NameToLayer("notAttack");
                anim.SetBool("Attack",false);
                Destroy(target.gameObject);
                healthBar.transform.localScale = new Vector3(hp>0?hp/maxHp:0,healthBar.transform.localScale.y,healthBar.transform.localScale.z);
            }
            anim.SetBool("Attack",false);
        }

    }
    void OnTriggerExit2D(Collider2D target){
        if(target.tag=="Player"){
            anim.SetBool("Attack",false);
            gameObject.layer=LayerMask.NameToLayer("notAttack");
        }
    }
    void Changedirection(){
        collision = Physics2D.Linecast(starPos.position, endPos.position, 1 << LayerMask.NameToLayer("EnemyMoveRange"));
        if(!collision){
            Vector3 temp = transform.localScale;
            if(temp.x == 0.25f){
                temp.x = -0.25f;
            }
            else{
                temp.x=0.25f;
            }
            transform.localScale = temp;
        }
    }
}
