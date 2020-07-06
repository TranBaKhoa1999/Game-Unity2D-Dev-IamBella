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
    [SerializeField]
    public Text healthCost;
    public int hecost;
    [SerializeField]
    public Text healthLevel; 

// giá
    private int ShieldCross = 10;

     void Start() {
        MoneyTxt.text= MainMenuController.Money.ToString();
        Shieldtxt.text = MainMenuController.Shield.ToString();
        int he = MainMenuController.HealthLevel;
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
    }
    void Update()
    {
        //show money
        MoneyTxt.text=MainMenuController.Money.ToString();
        MoneyTxt2.text= MainMenuController.Money.ToString();
        MoneyTxt3.text = MainMenuController.Money.ToString();
        Shieldtxt.text = MainMenuController.Shield.ToString();
        //show health level current + cost
        int he = MainMenuController.HealthLevel;
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
        //show level current

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
    // skill store
    public void UpHealth(){
        if(MainMenuController.Money> hecost){
            MainMenuController.HealthLevel+=1;
            MainMenuController.Money-=hecost;
            MainMenuController.SaveData();
            Update();
        }
    }
}
