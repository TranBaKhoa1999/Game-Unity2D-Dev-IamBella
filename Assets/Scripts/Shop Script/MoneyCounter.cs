using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MoneyCounter : MonoBehaviour
{
    [SerializeField]
    public Text MoneyTxt; // money game play
    [SerializeField]
    public Text MoneyTxt2; // money item shop
    [SerializeField]
    public Text MoneyTxt3; // money skill shop
    [SerializeField]
    public GameObject ItemStore;
    [SerializeField]
    public GameObject SkillStore;

    // txt cost
    //health
    [SerializeField]
    public Text healthCost;
    private int hecost;
    private int he;
    [SerializeField]
    public Text healthLevel; 
    private int healthAmount;

    //physic dmg
    [SerializeField]
    public Text physicCost;
    private int phy;
    private int phycost;
    [SerializeField]
    public Text physicLevel; 
    private int physicAmount;

    //maigc dmg
    [SerializeField]
    public Text magicCost;
    private int ma;
    private int macost;
    [SerializeField]
    public Text magicLevel; 
    private int magicAmount;

    //armor
    [SerializeField]
    public Text armorCost;
    private int ar;
    private int arcost;
    [SerializeField]
    public Text armorLevel; 
    private int armorAmount;
    // txt item Store;

    [SerializeField]
    public Text armorLv1_txt;
    [SerializeField]
    public Text armorLv2_txt;
    [SerializeField]
    public Text armorLv3_txt;
    [SerializeField]
    public Text swordLv1_txt;
    [SerializeField]
    public Text swordLv2_txt;
    [SerializeField]
    public Text swordLv3_txt;
    [SerializeField]
    public Text hpRestoreLv1_txt;
    [SerializeField]
    public Text hpRestoreLv2_txt;
    
    
    


// item Cost
    private int Armor1_Cost = 1000;
    private int Armor2_Cost = 3000;
    private int Armor3_Cost = 5000;
    private int Sword1_Cost = 1000;
    private int Sword2_Cost = 4000;
    private int Sword3_Cost = 8000;
    private int HpRestore1_Cost = 2000;
    private int HpRestore2_Cost = 5000;
//end
    // show store item in gameplay
    [SerializeField]
    private Text hpLv1ItemTxt;
    [SerializeField]
    private Text hpLv2ItemTxt;
    [SerializeField]
    private Text armorLv1ItemTxt;
    [SerializeField]
    private Text armorLv2ItemTxt;
    [SerializeField]
    private Text armorLv3ItemTxt;
    [SerializeField]
    private Text swordLv1ItemTxt;
    [SerializeField]
    private Text swordLv2ItemTxt;
    [SerializeField]
    private Text swordLv3ItemTxt;
    // button buy item ( code ko cho up skill khi đang trong game)
    [SerializeField]
    private Button upMaigc;
    [SerializeField]
    private Button upHp;
    [SerializeField]
    private Button upPhysic;
    [SerializeField]
    private Button upArmor;
    //

    //player value after use item
    public static int tmpPhysicDmg;
    public static int tmpArmor;
    //

    //end
     void Start() {
        tmpPhysicDmg = MainMenuController.PhysicDmg;
        tmpArmor = MainMenuController.Armor;
        
        Scene m_Scene;
        m_Scene = SceneManager.GetActiveScene();
        if(m_Scene.name !="LevelMenu"){
            upMaigc.interactable = false;
            upHp.interactable = false;
            upPhysic.interactable= false;
            upArmor.interactable = false;
        }
        else{
            upMaigc.interactable = true;
            upHp.interactable = true;
            upPhysic.interactable= true;
            upArmor.interactable = true;
        }
        MoneyTxt.text= MainMenuController.Money.ToString();
        //Shieldtxt.text = MainMenuController.Shield.ToString();
        armorLv1_txt.text = "You Have: "+ MainMenuController.ArmorLv1.ToString();
        armorLv2_txt.text = "You Have: "+ MainMenuController.ArmorLv2.ToString();
        armorLv3_txt.text = "You Have: "+ MainMenuController.ArmorLv3.ToString();
        swordLv1_txt.text = "You Have: "+ MainMenuController.SwordLv1.ToString();
        swordLv2_txt.text = "You Have: "+ MainMenuController.SwordLv2.ToString();
        swordLv3_txt.text = "You Have: "+ MainMenuController.SwordLv3.ToString();
        hpRestoreLv1_txt.text = "You Have: "+ MainMenuController.HpRestoreLv1.ToString();
        hpRestoreLv2_txt.text = "You Have: "+ MainMenuController.HpRestoreLv2.ToString();

        // health up
        he = MainMenuController.HealthLevel;
        hecost=0;
        healthLevel.text="Current: lv"+he;
        if( he==0){
            hecost=1000;
            healthCost.text = "1000";
        }
        else if(he==1){
            hecost=3000;
            healthCost.text = "3000";
        }
        else if(he==2){
            hecost=8000;
            healthCost.text = "8000";
        }
        else if(he==3){
            hecost=15000;
            healthCost.text = "15000";
        }
        else if(he==4){
            hecost=30000;
            healthCost.text = "30000";
        }
        else if (he==5){
            hecost=50000;
            healthCost.text = "50000";
        }
        else if (he==6){
            hecost=200000;
            healthCost.text = "200000";
        }
        else {
            hecost=9999999;
            healthCost.text= "MAX";
        }
        //end healthup
        //armor up
        ar = MainMenuController.ArmorLevel;
        arcost=0;
        armorLevel.text="Current: lv"+ar;
        if( ar==0){
            arcost=1000;
            armorCost.text = "1000";
        }
        else if(ar==1){
            arcost=2000;
            armorCost.text = "2000";
        }
        else if(ar==2){
            arcost=5000;
            armorCost.text = "5000";
        }
        else if(ar==3){
            arcost=8000;
            armorCost.text = "8000";
        }
        else if(ar==4){
            arcost=15000;
            armorCost.text = "15000";
        }
        else if (ar==5){
            arcost=30000;
            armorCost.text = "30000";
        }
        else if (ar==6){
            arcost=50000;
            armorCost.text = "50000";
        }
        else if (ar==7){
            arcost=200000;
            armorCost.text = "200000";
        }
        else {
            arcost=9999999;
            armorCost.text= "MAX";
        }
        //end

        //physic damge up
        phy = MainMenuController.PhysicLevel;
        phycost=0;
        physicLevel.text="Current: lv"+phy;
        if( phy==0){
            phycost=1000;
            physicCost.text = "1000";
        }
        else if(phy==1){
            phycost=2000;
            physicCost.text = "2000";
        }
        else if(phy==2){
            phycost=5000;
            physicCost.text = "5000";
        }
        else if(phy==3){
            phycost=8000;
            physicCost.text = "8000";
        }
        else if(phy==4){
            phycost=13000;
            physicCost.text = "13000";
        }
        else if (phy==5){
            phycost=20000;
            physicCost.text = "20000";
        }
        else if (phy==6){
            phycost=35000;
            physicCost.text = "35000";
        }
        else if (phy==7){
            phycost=100000;
            physicCost.text = "100000";
        }
        else{
            physicCost.text="MAX";
            phycost=9999999;
        }
        //end physic damge up
        
        //magic damge up
        ma = MainMenuController.MagicLevel;
        macost=0;
        magicLevel.text="Current: lv"+ma;
        if( ma==0){
            macost=1000;
            magicCost.text = "10000";
        }
        else if(ma==1){
            macost=2000;
            magicCost.text = "25000";
        }
        else if(ma==2){
            macost=5000;
            magicCost.text = "50000";
        }
        else if(ma==3){
            magicCost.text="MAX";
            macost=9999999;
        }
        else{
            magicCost.text="MAX";
            macost=9999999;
        }

        //end magic damgeup
    }
    void Update()
    {
        //show money
        MoneyTxt.text=MainMenuController.Money.ToString();
        MoneyTxt2.text= MainMenuController.Money.ToString();
        MoneyTxt3.text = MainMenuController.Money.ToString();
//        Shieldtxt.text = MainMenuController.Shield.ToString();
        armorLv1_txt.text = "You Have: "+ MainMenuController.ArmorLv1.ToString();
        armorLv2_txt.text = "You Have: "+ MainMenuController.ArmorLv2.ToString();
        armorLv3_txt.text = "You Have: "+ MainMenuController.ArmorLv3.ToString();
        swordLv1_txt.text = "You Have: "+ MainMenuController.SwordLv1.ToString();
        swordLv2_txt.text = "You Have: "+ MainMenuController.SwordLv2.ToString();
        swordLv3_txt.text = "You Have: "+ MainMenuController.SwordLv3.ToString();
        hpRestoreLv1_txt.text = "You Have: "+ MainMenuController.HpRestoreLv1.ToString();
        hpRestoreLv2_txt.text = "You Have: "+ MainMenuController.HpRestoreLv2.ToString();
        //show health level current + cost
        he = MainMenuController.HealthLevel;
        hecost=0;
        healthLevel.text="Current: lv"+he;
        if( he==0){
            hecost=1000;
            healthAmount=200;
            healthCost.text = "1000";
        }
        else if(he==1){
            hecost=3000;
            healthAmount=400;
            healthCost.text = "3000";
        }
        else if(he==2){
            hecost=8000;
            healthAmount=700;
            healthCost.text = "8000";
        }
        else if(he==3){
            hecost=15000;
            healthAmount=1000;
            healthCost.text = "15000";
        }
        else if(he==4){
            hecost=30000;
            healthAmount=1500;
            healthCost.text = "30000";
        }
        else if (he==5){
            hecost=50000;
            healthAmount=2000;
            healthCost.text = "50000";
        }
        else if (he==6){
            hecost=200000;
            healthAmount=5000;
            healthCost.text = "200000";
        }
        else{
            healthAmount=5000;
            healthCost.text="MAX";
            hecost=9999999;
        }
        //end healthup
        //armor up
        ar = MainMenuController.ArmorLevel;
        arcost=0;
        armorLevel.text="Current: lv"+ar;
        if( ar==0){
            arcost=1000;
            armorAmount = 20;
            armorCost.text = "1000";
        }
        else if(ar==1){
            arcost=2000;
            armorAmount = 40;
            armorCost.text = "2000";
        }
        else if(ar==2){
            arcost=5000;
            armorAmount = 70;
            armorCost.text = "5000";
        }
        else if(ar==3){
            arcost=8000;
            armorAmount = 100;
            armorCost.text = "8000";
        }
        else if(ar==4){
            arcost=15000;
            armorAmount = 150;
            armorCost.text = "15000";
        }
        else if (ar==5){
            arcost=30000;
            armorAmount = 200;
            armorCost.text = "30000";
        }
        else if (ar==6){
            arcost=50000;
            armorAmount = 300;
            armorCost.text = "50000";
        }
        else if (ar==7){
            arcost=200000;
            armorAmount = 400;
            armorCost.text = "200000";
        }
        else {
            armorAmount = 400;
            arcost=9999999;
            armorCost.text= "MAX";
        }
        //end
        //physic damge up
        phy = MainMenuController.PhysicLevel;
        phycost=0;
        physicLevel.text="Current: lv"+phy;
        if( phy==0){
            phycost=1000;
            physicAmount=23;
            physicCost.text = "1000";
        }
        else if(phy==1){
            phycost=2000;
            physicAmount=26;
            physicCost.text = "2000";
        }
        else if(phy==2){
            phycost=5000;
            physicAmount=30;
            physicCost.text = "5000";
        }
        else if(phy==3){
            phycost=8000;
            physicAmount=40;
            physicCost.text = "8000";
        }
        else if(phy==4){
            phycost=13000;
            physicAmount=55;
            physicCost.text = "13000";
        }
        else if (phy==5){
            phycost=20000;
            physicAmount=75;
            physicCost.text = "20000";
        }
        else if (phy==6){
            phycost=35000;
            physicAmount=100;
            physicCost.text = "35000";
        }
        else if (phy==7){
            phycost=100000;
            physicAmount=200;
            physicCost.text = "100000";
        }
        else{
            physicAmount=200;
            physicCost.text="MAX";
            phycost=9999999;
        }
        //end physic damge up
        
        //magic damge up
        ma = MainMenuController.MagicLevel;
        macost=0;
        magicLevel.text="Current: lv"+ma;
        if( ma==0){
            macost=10000;
            magicAmount=200;
            magicCost.text = "10000";
        }
        else if(ma==1){
            macost=25000;
            magicAmount=300;
            magicCost.text = "25000";
        }
        else if(ma==2){
            macost=50000;
            magicAmount=500;
            magicCost.text = "50000";
        }
        else if(ma==3){
            magicAmount=500;
            magicCost.text="MAX";
            macost=9999999;
        }
        else{

        }
        //end magic damgeup
        //number item store in game play
        hpLv1ItemTxt.text = "X "+MainMenuController.HpRestoreLv1.ToString();
        hpLv2ItemTxt.text = "X "+MainMenuController.HpRestoreLv2.ToString();
        armorLv1ItemTxt.text = "X "+MainMenuController.ArmorLv1.ToString();
        armorLv2ItemTxt.text = "X "+MainMenuController.ArmorLv2.ToString();
        armorLv3ItemTxt.text = "X "+MainMenuController.ArmorLv3.ToString();
        swordLv1ItemTxt.text = "X "+MainMenuController.SwordLv1.ToString();
        swordLv2ItemTxt.text = "X "+MainMenuController.SwordLv2.ToString();
        swordLv3ItemTxt.text = "X "+MainMenuController.SwordLv3.ToString();
        //end

    }
    // item store
    public void BuyArmor1(){
        if(MainMenuController.Money >= Armor1_Cost){
            MainMenuController.ArmorLv1+=1;
            MainMenuController.Money -= Armor1_Cost;
            MainMenuController.SaveData();
            Update();
            Debug.Log(MainMenuController.Money);
        }
    }
    public void BuyArmor2(){
        if(MainMenuController.Money >= Armor2_Cost){
            MainMenuController.ArmorLv2+=1;
            MainMenuController.Money -= Armor2_Cost;
            MainMenuController.SaveData();
            Update();
            Debug.Log(MainMenuController.Money);
        }
    }
    public void BuyArmor3(){
        if(MainMenuController.Money >= Armor3_Cost){
            MainMenuController.ArmorLv3+=1;
            MainMenuController.Money -= Armor3_Cost;
            MainMenuController.SaveData();
            Update();
            Debug.Log(MainMenuController.Money);
        }
    }
    public void BuySword1(){
        if(MainMenuController.Money >= Sword1_Cost){
            MainMenuController.SwordLv1+=1;
            MainMenuController.Money -= Sword1_Cost;
            MainMenuController.SaveData();
            Update();
            Debug.Log(MainMenuController.Money);
        }
    }
    public void BuySword2(){
        if(MainMenuController.Money >= Sword2_Cost){
            MainMenuController.SwordLv2+=1;
            MainMenuController.Money -= Sword2_Cost;
            MainMenuController.SaveData();
            Update();
            Debug.Log(MainMenuController.Money);
        }
    }
    public void BuySword3(){
        if(MainMenuController.Money >= Sword3_Cost){
            MainMenuController.SwordLv3+=1;
            MainMenuController.Money -= Sword3_Cost;
            MainMenuController.SaveData();
            Update();
            Debug.Log(MainMenuController.Money);
        }
    }
    public void BuyHp1(){
        if(MainMenuController.Money >= HpRestore1_Cost){
            MainMenuController.HpRestoreLv1+=1;
            MainMenuController.Money -= HpRestore1_Cost;
            MainMenuController.SaveData();
            Update();
            Debug.Log(MainMenuController.Money);
        }
    }
    public void BuyHp2(){
        if(MainMenuController.Money >= HpRestore2_Cost){
            MainMenuController.HpRestoreLv2+=1;
            MainMenuController.Money -= HpRestore2_Cost;
            MainMenuController.SaveData();
            Update();
            Debug.Log(MainMenuController.Money);
        }
    }
    public void ChangeStore(){
        if(ItemStore.activeSelf==true){
            SkillStore.SetActive(true);
            ItemStore.SetActive(false);
        }
        else{
            SkillStore.SetActive(false);
            ItemStore.SetActive(true);
        }
    }

    //------------------- END item store---------------------------------------


    // skill store
    public void UpHealth(){
        if(MainMenuController.Money> hecost && MainMenuController.HealthLevel<7){
            MainMenuController.HealthLevel+=1;
            MainMenuController.Money-=hecost;
            MainMenuController.Health = healthAmount;
            MainMenuController.SaveData();
            Update();
            //Debug.Log(MainMenuController.Health);
        }
    }
    public void UpArmor(){
        if(MainMenuController.Money> arcost && MainMenuController.ArmorLevel<8){
            MainMenuController.ArmorLevel+=1;
            MainMenuController.Money-=arcost;
            MainMenuController.Armor = armorAmount;
            MainMenuController.SaveData();
            Update();
            //Debug.Log(MainMenuController.Health);
        }
    }
    public void UpPhysicDmg(){
        if(MainMenuController.Money> phycost && MainMenuController.PhysicLevel<8){
            MainMenuController.PhysicLevel+=1;
            MainMenuController.Money-=phycost;
            MainMenuController.PhysicDmg = physicAmount;
            MainMenuController.SaveData();
            Update();
            //Debug.Log(MainMenuController.Health);
        }
    }
    public void UpMagicDmg(){
        if(MainMenuController.Money> macost && MainMenuController.MagicLevel<4){
            MainMenuController.MagicLevel+=1;
            MainMenuController.Money-=macost;
            MainMenuController.MagicDmg = magicAmount;
            MainMenuController.SaveData();
            Update();
            //Debug.Log(MainMenuController.Health);
        }
    }
    // ----------------------- End skill store ------------------------------
    // Use Item
    public void Hp1Use(){
        // float maxHealth = Moving.maxHealth;
        // float health = Moving.health;
        if(MainMenuController.HpRestoreLv1>0){
            float hpPlus = Moving.maxHealth * 20 / 100;
            if(Moving.health + hpPlus >Moving.maxHealth){
                Moving.health = Moving.maxHealth;
            }
            else {
                Moving.health += hpPlus;
            }
            MainMenuController.HpRestoreLv1--;
            MainMenuController.SaveData();
        }
    }
    public void Hp2Use(){
        if(MainMenuController.HpRestoreLv2>0){
            float hpPlus = Moving.maxHealth * 50 / 100;
            if(Moving.health + hpPlus >Moving.maxHealth){
                Moving.health = Moving.maxHealth;
            }
            else {
                Moving.health += hpPlus;
            }
            MainMenuController.HpRestoreLv2--;
            MainMenuController.SaveData();
        }
    }
    public void Armor1Use(){
        if(MainMenuController.ArmorLv1>0){
            tmpArmor+=10;
            MainMenuController.ArmorLv1--;
            MainMenuController.SaveData();
            Debug.Log("used");
        }
    }
    public void Armor2Use(){
        if(MainMenuController.ArmorLv2>0){
            tmpArmor+=30;
            MainMenuController.ArmorLv2--;
            MainMenuController.SaveData();
            Debug.Log("used");
        }
    }
    public void Armor3Use(){
        if(MainMenuController.ArmorLv3>0){
            tmpArmor+=50;
            MainMenuController.ArmorLv3--;
            MainMenuController.SaveData();
            Debug.Log("used");
        }
    }
    public void Sword1Use(){
        if(MainMenuController.SwordLv1>0){
            tmpPhysicDmg+=10;
            MainMenuController.SwordLv1--;
            MainMenuController.SaveData();
            Debug.Log("used");
        }
    }
    public void Sword2Use(){
        if(MainMenuController.SwordLv2>0){
            tmpPhysicDmg+=30;
            MainMenuController.SwordLv2--;
            MainMenuController.SaveData();
            Debug.Log("used");
        }
    }
    public void Sword3Use(){
        if(MainMenuController.SwordLv3>0){
            tmpPhysicDmg+=50;
            MainMenuController.SwordLv3--;
            MainMenuController.SaveData();
            Debug.Log("used");
        }
    }
    //end
}
