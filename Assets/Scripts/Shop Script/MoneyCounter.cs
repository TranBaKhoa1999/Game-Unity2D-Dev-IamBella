using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyCounter : MonoBehaviour
{
    [SerializeField]
    public Text MoneyTxt;
    [SerializeField]
    public Text MoneyTxt2;
    [SerializeField]
    public Text Shieldtxt;
// giá
    private int ShieldCross = 10;

     void Start() {
        MoneyTxt.text= MainMenuController.Money.ToString();
        Shieldtxt.text = MainMenuController.Shield.ToString();
    }
    void FixedUpdate()
    {
        MoneyTxt.text=MainMenuController.Money.ToString();
        MoneyTxt2.text= MainMenuController.Money.ToString();
        Shieldtxt.text = MainMenuController.Shield.ToString();
    }
    public void BuyShield(){
        if(MainMenuController.Money >= ShieldCross){
            MainMenuController.Shield+=1;
            MainMenuController.Money -= ShieldCross;
            MainMenuController.SaveData();
            FixedUpdate();
            Debug.Log(MainMenuController.Money);
        }
    }

}
