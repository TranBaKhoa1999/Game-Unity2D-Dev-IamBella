using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    public float moveForce = 20f; // tốc độ chạy
    public float jumpForce = 700f; // độ cao nhảy
    public float maxVelocity = 4f; // vận tốc

    public bool grounded;

    private Rigidbody2D myBody;
    private Animator anim;
    private bool shotable=true;
    public float minX,maxX;
    public Transform player;

    [SerializeField]
    public GameObject bullet;
    void Awake(){
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    
    }
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MagicalAttack();
        if(anim.GetCurrentAnimatorStateInfo(0).IsName("PhysicalAttack") && // code sau khi hoàn thành đánh thường thì ko đánh lại lần nữa
            anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
            {
                anim.SetBool("isPhysicalAttack", false);
            }
        if(anim.GetCurrentAnimatorStateInfo(0).IsName("MagicalAttack") &&  // code sau khi hoàn thành vận skill thì ko vận lại lần nữa
        anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {
            anim.SetBool("isMagicalAttack", false);
        }

        if(anim.GetCurrentAnimatorStateInfo(0).IsName("MagicalAttack")){ // nếu đang vận skill magic thì ko cho di chuyển
            transform.position = transform.position;
        }
        else{
                    PlayerMoveKeyboard();
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
            scale.x = -0.639f;
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
            scale.x = 0.639f;
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
                shotable=true;
 // ------------------------------------------- End test -------------------------
            }
        }
        if(Input.GetKey (KeyCode.Return)){
            if(anim.GetBool("Jump")==true){
                
            }
            else{
                if(anim.GetBool("isMagicalAttack")==false && grounded){
                    anim.SetBool("isPhysicalAttack",true);
                }
            }
        }
        // else if(Input.GetKey (KeyCode.L)){
        //     if(anim.GetBool("isPhysicalAttack")==false & grounded){
        //         anim.SetBool("isMagicalAttack",true);
        //         //MagicalAttack();
        //     }
        // }
        myBody.AddForce( new Vector2(forceX,forceY));
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
    }

    void MagicalAttack(){

        if(Input.GetKey (KeyCode.L) && shotable){;
            if(anim.GetBool("isPhysicalAttack")==false & grounded){
                anim.SetBool("isMagicalAttack",true);
                // BulletShow();
                StartCoroutine("BulletShow");
                // Instantiate(bullet, transform.position, Quaternion.Euler(new Vector3(0, 0, 0 )));
                shotable=false;
            }
        }
    }
         private IEnumerator BulletShow()
     {        
         //Wait for 14 secs.
         yield return new WaitForSeconds(0.3f);
         if(transform.localScale.x < 0){
            Instantiate(bullet, new Vector2(transform.position.x+1f,transform.position.y), Quaternion.Euler(new Vector3(0, 0, 0 )));
         }
         else{
            Instantiate(bullet, new Vector2(transform.position.x-1f,transform.position.y), Quaternion.Euler(new Vector3(0, 0, 0 )));
         }

     }
}
