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
    public static bool level4{ get ; set ; }=false;
    public static bool level5{ get ; set ; }=false;
    public static int Shield=3;
    public static int Money=5000;

    public static int MagicDmg=100;
    public static int MagicLevel=0;

    public static int PhysicDmg=20;
    public static int PhysicLevel=0;

    public static int Health=100;
    public static int HealthLevel=0;

     public static void SaveData() {
         string savePath = Application.persistentDataPath + "/gamesave.dat";
         var save = new Save(){
           Level2 = level2,
           Level3 = level3,
           money = Money,
           health = Health,
           healthLevel=HealthLevel,
           magicLevel  = MagicLevel,
           magicDmg = MagicDmg,
           physicLevel = PhysicLevel,
           physicDmg = PhysicDmg,
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

            MagicDmg = save.magicDmg;
            MagicLevel = save.magicLevel;

            PhysicDmg = save.physicDmg;
            PhysicLevel = save.physicLevel;

            Health = save.health;
            HealthLevel = save.healthLevel;

            Debug.Log("Loaded");
        }
        else{
            Debug.Log("Load Fail");
            Money = 5000;
            Shield = 3;
            MagicDmg = 100;
            Health = 100;
            PhysicDmg = 20;
            HealthLevel = 0;
            PhysicLevel = 0;
            MagicLevel = 0;
        }
    }
     private void Awake() {
         LoadData();
         Debug.Log(HealthLevel);
         Debug.Log(Money);
    }
    private void Start() {
    }

}
