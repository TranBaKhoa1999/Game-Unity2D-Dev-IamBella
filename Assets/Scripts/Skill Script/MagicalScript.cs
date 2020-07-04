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
    void Awake(){
    }
    void Start()
    {
        side = player.transform.localScale.x;
        startPoint = player.transform.position.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
        if(transform.position.x - startPoint> 6.8){  // hủy đạn sau khi bay 1 khoảng cách so với điểm xuất phát ( thiếu hàm || )
            Destroy(gameObject);
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
