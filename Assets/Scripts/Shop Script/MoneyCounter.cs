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

     void Start() {
        MoneyTxt.text= MainMenuController.Money.ToString();
    }
    void FixedUpdate()
    {
        MoneyTxt.text=MainMenuController.Money.ToString();
        MoneyTxt2.text= MainMenuController.Money.ToString();
    }

}
