using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class starbullet : MonoBehaviour
{
    private float speed = 7f;
    private Rigidbody2D myBody;
    private Vector2 moveDirector;
    private Transform player;
    public GameObject floatDamge;
    // Start is called before the first frame update
    void Awake(){
        player = GameObject.Find("Player").transform;
        myBody = GetComponent<Rigidbody2D>();
        
    }
    void Start()
    {
        // transform.LookAt(player.position);
        if(gameObject.name.Contains("(Clone)")){
            moveDirector =(player.position - transform.position).normalized * speed;
            myBody.velocity = new Vector2(moveDirector.x, moveDirector.y);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D target) {
        if(target.gameObject.tag == "Player"){
            Destroy(gameObject);
            float subtractDmg=0;
            subtractDmg =  Fairy.dmg - (Fairy.dmg*Moving.armor/10)/100<0?0:Fairy.dmg - (Fairy.dmg*Moving.armor/10)/100;

            Moving.health=(Moving.health - subtractDmg)<0? 0 : (Moving.health - subtractDmg);
            GameObject damgeShow = Instantiate(floatDamge,player.position, Quaternion.identity) as GameObject;
            damgeShow.transform.GetChild(0).GetComponent<TextMesh>().text =  "-" + subtractDmg.ToString();
            Destroy(damgeShow, 1f);
        }
    }
}
