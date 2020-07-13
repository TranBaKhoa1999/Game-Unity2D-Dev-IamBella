using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elf : MonoBehaviour
{
    private Rigidbody2D myBody;
    private Animator anim;
    private Transform player;
   [SerializeField]
    private GameObject bullet;
    public GameObject healthBar;
    public GameObject floatDamgePhysic;
    public GameObject floatDamgeMagic;
    private float nextFire;
    private float coolDown;
    private float hp;
    private float maxHp;
    private int cost;
    public static float dmg;
    private bool shotable = false;
    

     void Awake() {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        player = GameObject.Find("Player").transform;
        maxHp = 3000;
        cost = 1000;
        dmg=10f;
    }
    // Start is called before the first frame update
    void Start()
    {
        maxHp = 200;
        hp= 200;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(hp<=0){
            anim.SetBool("isDie",true);
        }
        // auto shot
        if(Vector3.Distance(transform.position,player.position) <=9){
            shotable = true;
            anim.SetBool("Attack",true);
            if(anim.GetCurrentAnimatorStateInfo(0).IsName("Attack") && anim.GetCurrentAnimatorStateInfo(0).normalizedTime <= 0.01f)
            {
                GameObject damgeShow = Instantiate(floatDamgePhysic,player.transform.position, Quaternion.identity) as GameObject;
                damgeShow.transform.GetChild(0).GetComponent<TextMesh>().text =  "+"+cost+" Coin";
            }
            GameObject clone =Instantiate(bullet, new Vector2(transform.position.x,transform.position.y),bullet.transform.rotation) as GameObject;
            nextFire = Time.time+coolDown;
        }
        else{
            anim.SetBool("Attack",false);
        }
        //check die
        if(anim.GetCurrentAnimatorStateInfo(0).IsName("Die") && anim.GetCurrentAnimatorStateInfo(0).normalizedTime <= 0.01f)
        {
            GameObject damgeShow = Instantiate(floatDamgePhysic,player.transform.position, Quaternion.identity) as GameObject;
            damgeShow.transform.GetChild(0).GetComponent<TextMesh>().text =  "+"+cost+" Coin";
        }
        if(anim.GetCurrentAnimatorStateInfo(0).IsName("Die") && anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.9f)
        {
            MainMenuController.Money+=cost;
            MainMenuController.SaveData();
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D target) {
        if(target.tag=="Bullet"){ // bị bắn
                hp -=Moving.magicDmg;
                //float ting magic damge
                GameObject damgeShow = Instantiate(floatDamgeMagic,transform.position, Quaternion.identity) as GameObject;
                damgeShow.transform.GetChild(0).GetComponent<TextMesh>().text = "-"+ Moving.magicDmg.ToString();
                Destroy(damgeShow, 1f);
    
                anim.SetTrigger("hurt");
                anim.SetBool("Attack",false);
                Destroy(target.gameObject);
                healthBar.transform.localScale = new Vector3(hp>0?hp/maxHp:0,healthBar.transform.localScale.y,healthBar.transform.localScale.z);
            }
    }
}
