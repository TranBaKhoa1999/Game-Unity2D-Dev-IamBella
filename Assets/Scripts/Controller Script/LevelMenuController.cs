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
    private Button level4;
    [SerializeField]
    private Button level5;
    [SerializeField]
    private GameObject block2;
    [SerializeField]
    private GameObject block3;
    [SerializeField]
    private GameObject block4;
    [SerializeField]
    private GameObject block5;
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
        if(MainMenuController.level4==false){
            level4.interactable = false;
            block4.SetActive(true);
        }
        else{
            level4.interactable = true;
            block4.SetActive(false);
           
        }
        if(MainMenuController.level5==false){
            level5.interactable = false;
            block5.SetActive(true);
        }
        else{
            level5.interactable = true;
            block5.SetActive(false);
           
        }
    }
    public void BackButtonOnClick(){
        FindObjectOfType<AudioManager>().Play("clickAudio");
         SceneManager.LoadScene("MainMenu");
    }
    public void PlayLevel1Onlick(){
        FindObjectOfType<AudioManager>().Play("clickAudio");
         SceneManager.LoadScene("Level1");
    }
    public void PlayLevel2Onlick(){
        FindObjectOfType<AudioManager>().Play("clickAudio");
         SceneManager.LoadScene("Level2");
    }
    public void PlayLevel3Onlick(){
        FindObjectOfType<AudioManager>().Play("clickAudio");
         SceneManager.LoadScene("Level3");
    }
    public void PlayLevel4Onlick(){
        FindObjectOfType<AudioManager>().Play("clickAudio");
         SceneManager.LoadScene("Level4");
    }
    public void PlayLevel5Onlick(){
        FindObjectOfType<AudioManager>().Play("clickAudio");
         SceneManager.LoadScene("Level5");
    }
    
}
