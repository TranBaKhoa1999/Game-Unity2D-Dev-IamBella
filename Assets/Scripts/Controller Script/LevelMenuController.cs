using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LevelMenuController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Button level2;
    [SerializeField]
    private Button level3;
    [SerializeField]
    private GameObject block2;
    [SerializeField]
    private GameObject block3;
     void Start() {
        if(MainMenuController.level2==false){
            level2.interactable = false;
            block2.SetActive(true);
        }
        else{
            level2.interactable = true;
            block2.SetActive(false);
        }
        if(MainMenuController.level3==false){
            level3.interactable = false;
            block3.SetActive(true);
        }
        else{
            level3.interactable = true;
            block3.SetActive(false);
           
        }
    }
    public void BackButtonOnClick(){
         SceneManager.LoadScene("MainMenu");
    }
    public void PlayLevel1Onlick(){
         SceneManager.LoadScene("Level1");
    }
    public void PlayLevel2Onlick(){
         SceneManager.LoadScene("Level2");
    }
    
}
