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
        player = GameObject.Find("Player").transform;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 tmp = transform.localScale;
        tmp.y -=30;
        if(Vector2.Distance(transform.position,player.position)<=10){
           transform.GetComponent<Rigidbody2D>().simulated=true;
            Destroy(gameObject,3f);
        }
    }
}
