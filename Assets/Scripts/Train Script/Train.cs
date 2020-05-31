using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Train : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 1f;

    private Rigidbody2D myBody;

    void Awake(){
        myBody = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }

    void Move(){
        myBody.velocity = new Vector2(transform.localScale.x, 0) * speed * -1;
    }
}
