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

    public float minX,maxX;
    public Transform player;
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
            PlayerMoveKeyboard();
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
            scale.x = 1f;
            transform.localScale = scale;

            anim.SetBool("Run",true);
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
            scale.x = -1f;
            transform.localScale = scale;

            anim.SetBool("Run",true);
        }
        else if(h==0){
            anim.SetBool("Run",false);
        }
        if(Input.GetKey (KeyCode.Space)){
            if(grounded){
                grounded =false;
                forceY= jumpForce;
            }
        }
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
}
