using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gobin : MonoBehaviour
{
    [SerializeField]
    private Transform starPos,endPos;
    private bool collision; // bắt va chạm
    public float speed = 1f;
    private Rigidbody2D myBody;
    private Animator anim;
    [SerializeField]
    private float hp;
    public GameObject healthBar;
    // Start is called before the first frame update
    void Awake() {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        bool x = anim.GetBool("isDie");
        if(hp<=0){
            anim.SetBool("isDie",true);
             gameObject.layer=LayerMask.NameToLayer("notAttack");
            speed=0;
            // Destroy(gameObject);
        }
        if(anim.GetCurrentAnimatorStateInfo(0).IsName("Die") && anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.9f){
            Destroy(gameObject);
        }
         //Debug.Log(anim.GetBool("isDie"));
            Changedirection();
            Move();
            
    }
    void Move(){
            myBody.velocity = new Vector2(transform.localScale.x, 0) * speed;
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
                healthBar.transform.localScale = new Vector3(hp>0?hp/100:0,healthBar.transform.localScale.y,healthBar.transform.localScale.z);
            }
            //anim.SetBool("Attack",true);
            // Debug.Log(delta);

            //Destroy(target.gameObject);
        }
        else{
            if(target.tag=="Bullet"){ // bị bắn
                hp -=Moving.magicDmg;
                anim.SetTrigger("hurt");
                gameObject.layer=LayerMask.NameToLayer("notAttack");
                anim.SetBool("Attack",false);
                Destroy(target.gameObject);
                healthBar.transform.localScale = new Vector3(hp>0?hp/100:0,healthBar.transform.localScale.y,healthBar.transform.localScale.z);
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
