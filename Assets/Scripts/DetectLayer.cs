using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectLayer : MonoBehaviour
{
    private Transform player;
    public Transform playerpos;
    private bool colli;
    private int x;
    // Start is called before the first frame update
    void Awake(){
        player = GameObject.Find("Player").transform;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // //RaycastHit2D hit;
        // // Debug.Log(RaycastHit2D);
        // colli = Physics2D.Linecast(player.position, playerpos.position,1 << LayerMask.NameToLayer("Temp"));
        // if(colli){
        //     gameObject.layer=LayerMask.NameToLayer("EnemyFollowRange");
        // }
        // else{
        //     gameObject.layer=LayerMask.NameToLayer("EnemyMoveRange");
        // }
    }
    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag== "Player"){
            gameObject.layer=LayerMask.NameToLayer("EnemyFollowRange");
        }
    }
    void OnTriggerExit2D(Collider2D other) {
        if(other.tag =="Player"){
            gameObject.layer=LayerMask.NameToLayer("EnemyMoveRange");
        }
    }
}
