using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
[RequireComponent(typeof(MainMenuController))]
public class SaveScript : MonoBehaviour
{
    // Start is called before the first frame update
    private MainMenuController gameData;
    private static string savePath;
    void Start()
    {
        savePath = Application.persistentDataPath + "/gamesave.dat";
    }

    // Update is called once per frame
    public static void SaveData()
    {
        var save = new Save(){
           Level2 = MainMenuController.level2,
           Level3 = MainMenuController.level3,
           money = MainMenuController.Money
        };

        var binaryFormatter = new BinaryFormatter();

        using ( var fileSteam = File.Create(savePath)){

            binaryFormatter.Serialize(fileSteam,save);
        }
        Debug.Log("Saved");
    }
    public static void LoadData(){

        if(File.Exists(savePath)){

            Save save;
            
            var binaryFormatter = new BinaryFormatter();

            using(var fileSteam = File.Open(savePath, FileMode.Open) ){

                save = (Save)binaryFormatter.Deserialize(fileSteam);
            }
            MainMenuController.level2 = save.Level2;
            MainMenuController.level3= save.Level3;
            MainMenuController.Money = 7000;
            Debug.Log("Loaded");
        }
        else{
            Debug.Log("Load Fail");
        }
        
    }
}
