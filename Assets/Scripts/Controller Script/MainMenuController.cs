using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.SceneManagement;
public class MainMenuController : MonoBehaviour
{
    public void PlayGame(){
         SceneManager.LoadScene("LevelMenu");
    }
    public static bool level3 { get ; set ; }=false;
    public static bool level2{ get ; set ; }=false;
    public static int Shield;
    public static int Money;
     public static void SaveData() {
         string savePath = Application.persistentDataPath + "/gamesave.dat";
         var save = new Save(){
           Level2 = level2,
           Level3 = level3,
           money = Money,
           shield = Shield
        };

        var binaryFormatter = new BinaryFormatter();

        using ( var fileSteam = File.Create(savePath)){

            binaryFormatter.Serialize(fileSteam,save);
        }
        Debug.Log("Saved");
    }
    public static void LoadData(){
        string savePath = Application.persistentDataPath + "/gamesave.dat";
        if(File.Exists(savePath)){

            Save save;
            
            var binaryFormatter = new BinaryFormatter();

            using(var fileSteam = File.Open(savePath, FileMode.Open) ){

                save = (Save)binaryFormatter.Deserialize(fileSteam);
            }
            level2 = save.Level2;
            level3= save.Level3;
            Money = save.money;
            Shield = save.shield;
            Debug.Log("Loaded");
        }
        else{
            Debug.Log("Load Fail");
            Money = 5000;
            Shield = 3;
        }
    }
     private void Awake() {
         LoadData();
         Debug.Log(Money);
    }
    private void Start() {
    }

}
