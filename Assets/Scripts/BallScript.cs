using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D myBody;
    private Transform player;
    private float speed = 10f;
    void Awake() {
        myBody = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    void Move(){
        myBody.velocity = new Vector2(transform.localScale.x, 0) * speed;
    }
}
