using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicalScript : MonoBehaviour
{
    // Start is called before the first frame update
    private float speed = 13f;
    public Transform player;
    private float side;
    void Awake(){
    }
    void Start()
    {
        side = player.transform.localScale.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
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
