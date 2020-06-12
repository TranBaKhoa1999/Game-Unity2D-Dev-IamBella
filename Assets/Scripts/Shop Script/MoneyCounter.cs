using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyCounter : MonoBehaviour
{
    [SerializeField]
    public Text MoneyTxt;

     void Start() {
        MoneyTxt.text= MainMenuController.Money.ToString();
    }
    void FixedUpdate()
    {
        MoneyTxt.text=MainMenuController.Money.ToString();
    }

}
