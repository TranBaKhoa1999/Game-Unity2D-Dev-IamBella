using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicalScript : MonoBehaviour
{
    // Start is called before the first frame update
    private float speed = 14f;
    public Transform player;
    private float side;
    private float startPoint;
    private Animator anim;
    void Awake(){
        anim = GetComponent<Animator>();
    }
    void Start()
    {
        side = player.transform.localScale.x;
        startPoint = player.transform.position.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        if (gameObject.name.Contains("(Clone)"))
        {
            if(Moving.magicLevel == 0){
                anim.SetInteger("Level",0);
            }
            else if (Moving.magicLevel==1){
                anim.SetInteger("Level",1);
            }
            else if(Moving.magicLevel ==2){
                anim.SetInteger("Level",2);
            }
            else if(Moving.magicLevel == 3){
                anim.SetInteger("Level",3);
            }
            Move();
            if(Mathf.Abs(transform.position.x - startPoint)> 8){  // hủy đạn sau khi bay 1 khoảng cách so với điểm xuất phát ( thiếu hàm || )
            Destroy(gameObject);
            }

        }
    }

    void Move(){
        if(side<0){
            transform.Translate(transform.right * speed * Time.smoothDeltaTime);
        }
        else{
            transform.Translate(transform.right * speed * Time.smoothDeltaTime*-1);
        }
    }
}
