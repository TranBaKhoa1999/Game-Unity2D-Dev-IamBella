using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyCounter : MonoBehaviour
{
    [SerializeField]
    public Text MoneyTxt; // money game play
    [SerializeField]
    public Text MoneyTxt2; // money item shop
    [SerializeField]
    public Text MoneyTxt3; // money skill shop
    [SerializeField]
    public Text Shieldtxt;
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


// giá
    private int ShieldCross = 10;

     void Start() {
        MoneyTxt.text= MainMenuController.Money.ToString();
        Shieldtxt.text = MainMenuController.Shield.ToString();

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
        else {
            hecost=9999999;
            healthCost.text= "MAX";
        }
        //end healthup

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
        else{
            healthCost.text="MAX";
            phycost=9999999;
        }
        //end physic damge up
        
        //magic damge up

        //end magic damgeup
    }
    void Update()
    {
        //show money
        MoneyTxt.text=MainMenuController.Money.ToString();
        MoneyTxt2.text= MainMenuController.Money.ToString();
        MoneyTxt3.text = MainMenuController.Money.ToString();
        Shieldtxt.text = MainMenuController.Shield.ToString();
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
        else{
            healthAmount=2000;
            healthCost.text="MAX";
            hecost=9999999;
        }
        //end healthup

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
        else{
            physicAmount=100;
            healthCost.text="MAX";
            phycost=9999999;
        }
        //end physic damge up
        
        //magic damge up
        ma = MainMenuController.MagicLevel;
        macost=0;
        magicLevel.text="Current: lv"+ma;
        if( ma==0){
            macost=1000;
            magicAmount=23;
            magicCost.text = "1000";
        }
        else if(ma==1){
            macost=2000;
            magicAmount=26;
            magicCost.text = "2000";
        }
        else if(ma==2){
            macost=5000;
            magicAmount=30;
            magicCost.text = "5000";
        }
        else if(ma==3){
            macost=8000;
            magicAmount=40;
            magicCost.text = "8000";
        }
        else{
            magicAmount=100;
            magicCost.text="MAX";
            macost=9999999;
        }
        //end magic damgeup

    }
    // item store
    public void BuyShield(){
        if(MainMenuController.Money >= ShieldCross){
            MainMenuController.Shield+=1;
            MainMenuController.Money -= ShieldCross;
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
        if(MainMenuController.Money> hecost && MainMenuController.HealthLevel<6){
            MainMenuController.HealthLevel+=1;
            MainMenuController.Money-=hecost;
            MainMenuController.Health = healthAmount;
            MainMenuController.SaveData();
            Update();
            //Debug.Log(MainMenuController.Health);
        }
    }
    public void UpPhysicDmg(){
        if(MainMenuController.Money> phycost && MainMenuController.PhysicLevel<7){
            MainMenuController.PhysicLevel+=1;
            MainMenuController.Money-=phycost;
            MainMenuController.PhysicDmg = physicAmount;
            MainMenuController.SaveData();
            Update();
            //Debug.Log(MainMenuController.Health);
        }
    }
    public void UpMagicDmg(){
        if(MainMenuController.Money> macost && MainMenuController.MagicLevel<3){
            MainMenuController.MagicLevel+=1;
            MainMenuController.Money-=macost;
            MainMenuController.MagicDmg = magicAmount;
            MainMenuController.SaveData();
            Update();
            //Debug.Log(MainMenuController.Health);
        }
    }
    // ----------------------- End skill store ------------------------------
}
