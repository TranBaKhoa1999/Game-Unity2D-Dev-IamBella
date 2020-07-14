using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.SceneManagement;
public class MainMenuController : MonoBehaviour
{
    public static bool level3 { get ; set ; }=false;
    public static bool level2{ get ; set ; }=false;
    public static bool level4{ get ; set ; }=false;
    public static bool level5{ get ; set ; }=false;
    public static int Money=500000;

    //item
    public static int ArmorLv1=0;
    public static int ArmorLv2=0;
    public static int ArmorLv3=0;
    public static int SwordLv1=0;
    public static int SwordLv2=0;
    public static int SwordLv3=0;
    public static int HpRestoreLv1=0;
    public static int HpRestoreLv2=0;


    //skill - detail
    public static int MagicDmg=100;
    public static int MagicLevel=0;

    public static int PhysicDmg=20;
    public static int PhysicLevel=0;

    public static int Health=100;
    public static int HealthLevel=0;

    public static int Armor=10;
    public static int ArmorLevel=0;
    // panel
    public GameObject howToPlayPanel;

    public void PlayGame(){
            // Open all level for demo
            level2=true;
            level3=true;
            level4=true;
            level5=true;
         SceneManager.LoadScene("LevelMenu");
    }
     public static void SaveData() {
         string savePath = Application.persistentDataPath + "/gamesave.dat";
         var save = new Save(){
           Level2 = level2,
           Level3 = level3,
           Level4 = level4,
           Level5 = level5,
           money = Money,
           health = Health,
           healthLevel=HealthLevel,
           magicLevel  = MagicLevel,
           magicDmg = MagicDmg,
           physicLevel = PhysicLevel,
           physicDmg = PhysicDmg,
           armorLevel = ArmorLevel,
           armor = Armor,
           //item
           armorLv1 = ArmorLv1,
           armorLv2 = ArmorLv2,
           armorLv3 = ArmorLv3,
           swordLv1 = SwordLv1,
           swordLv2 = SwordLv2,
           swordLv3 = SwordLv3,
           hpRestoreLv1 = HpRestoreLv1,
           hpRestoreLv2 = HpRestoreLv2
        };

        var binaryFormatter = new BinaryFormatter();

        using ( var fileSteam = File.Create(savePath)){

            binaryFormatter.Serialize(fileSteam,save);
        }
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
            level4 = save.Level4;
            level5 = save.Level5;
            Money = save.money;

            MagicDmg = save.magicDmg;
            MagicLevel = save.magicLevel;

            PhysicDmg = save.physicDmg;
            PhysicLevel = save.physicLevel;

            Health = save.health;
            HealthLevel = save.healthLevel;

            Armor = save.armor;
            ArmorLevel = save.armorLevel;
            // item
            ArmorLv1 = save.armorLv1;
            ArmorLv2 = save.armorLv2;
            ArmorLv3 = save.armorLv3;
            SwordLv1 = save.swordLv1;
            SwordLv2 = save.swordLv2;
            SwordLv3 = save.swordLv3;
            HpRestoreLv1 = save.hpRestoreLv1;
            HpRestoreLv2 = save.hpRestoreLv2;
        }
        else{
            Money = 5000;
            MagicDmg = 100;
            Health = 100;
            PhysicDmg = 20;
            HealthLevel = 0;
            PhysicLevel = 0;
            MagicLevel = 0;
            Armor=10;
            ArmorLevel=0;
            ArmorLv1 = 0 ;
            ArmorLv2 = 0;
            ArmorLv3 = 0;
            SwordLv1 = 0;
            SwordLv2 = 0;
            SwordLv3 =0;
            HpRestoreLv1 = 0;
            HpRestoreLv2 = 0;
        }
    }
     private void Awake() {
         LoadData();
        //  Debug.Log(HealthLevel);
        //  Debug.Log(Money);
    }
    private void Start() {
    }
    public void HowToPlay(){
        howToPlayPanel.SetActive(true);
    }
    public void CloseHowToPlayPanel(){
        howToPlayPanel.SetActive(false);
    }

}
