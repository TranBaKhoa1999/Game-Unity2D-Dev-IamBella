using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gobin : MonoBehaviour
{
    [SerializeField]
    private Transform starPos,endPos;
    private bool collision; // bắt va chạm
    public float speed = 1f;
    private Rigidbody2D myBody;
    private Animator anim;
    public static float hp;
    // Start is called before the first frame update
    void Awake() {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    void Start()
    {
        hp=10;
    }

    void Changedirection(){
        collision = Physics2D.Linecast(starPos.position, endPos.position, 1 << LayerMask.NameToLayer("Ground"));
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
    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
        Changedirection();
    }
    void Move(){
        myBody.velocity = new Vector2(transform.localScale.x, 0) * speed;
    }
     void OnTriggerEnter2D(Collider2D target) {
        if(target.tag == "Player"){
            Vector3 delta = target.transform.position - transform.position;
        // check side trigger
            if(transform.localScale.x < 0){ // quái đi qua trái
                if(delta.x < delta.y){
                    anim.SetBool("Attack",true);
                }
            }
            else{ // quái đi qua phải
                if(delta.x>delta.y){
                    anim.SetBool("Attack",true);
                }
            }

            //anim.SetBool("Attack",true);
            Debug.Log(delta);

            //Destroy(target.gameObject);
        }
        else{
            if(target.tag=="Bullet"){
                hp -=1f;
                Destroy(target.gameObject);
                Debug.Log("damaged");
            }
            anim.SetBool("Attack",false);
        }

    }
    void OnTriggerExit2D(Collider2D target){
            anim.SetBool("Attack",false);
    }
}
