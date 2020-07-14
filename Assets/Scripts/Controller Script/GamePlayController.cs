using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Runtime.Serialization.Formatters.Binary;

public class GamePlayController : MonoBehaviour
{
    [SerializeField]
    private GameObject pausePanel;
    [SerializeField]
    private GameObject losePanel;
    [SerializeField]
    private GameObject winPanel;
    
    [SerializeField]
    private Button resumeButton;

    [SerializeField]
    private GameObject blurCanvas;

    [SerializeField]
    private GameObject shopPanel;

    [SerializeField]
    private GameObject skillShopPanel;

    //using Item 
    [SerializeField]
    private GameObject armorItemPanel;

    [SerializeField]
    private GameObject swordItemPanel;

    [SerializeField]
    private GameObject hpItemPanel;
    public static bool isWin;

    
    //end
    
    void FixedUpdate() {
        if(Moving.isDie == true){
            FindObjectOfType<AudioManager>().Play("gameOverAudio");
            StartCoroutine("PlayerDie");
        }
        if(isWin==true){
            StartCoroutine("PlayerWin");
            Debug.Log("win");
        }

    }
    private IEnumerator PlayerDie() // hàm delay thời gian bắn đạn
     {        
         yield return new WaitForSeconds(2f);
            LoseGame();
     }
     private IEnumerator PlayerWin() // hàm delay thời gian bắn đạn
     {        
        Scene m_Scene;
        m_Scene = SceneManager.GetActiveScene();
        Time.timeScale=1f;
        string currentlv = m_Scene.name.Substring(5);
        int crlv =int.Parse(currentlv);
        if(crlv==1){
            if(MainMenuController.level2==false){
                MainMenuController.level2 = true;
                MainMenuController.Money+=2000;
            }
            else{
                MainMenuController.Money+=500;
            }
            MainMenuController.SaveData();
        }
        else if(crlv ==2){
            if(MainMenuController.level3==false){
                MainMenuController.level3 = true;
                MainMenuController.Money+=5000;
            }
            else{
                MainMenuController.Money+=1000;
            }
            MainMenuController.SaveData();
        }
        else if(crlv ==3){
            if(MainMenuController.level4==false){
                MainMenuController.level4 = true;
                MainMenuController.Money+=10000;
            }
            else{
                MainMenuController.Money+=1800;
            }
            MainMenuController.SaveData();
        }
        else if(crlv ==4){
            if(MainMenuController.level5==false){
                MainMenuController.level5 = true;
                MainMenuController.Money+=15000;
            }
            else{
                MainMenuController.Money+=3000;
            }
            MainMenuController.SaveData();
        }
        else if(crlv ==5){
            MainMenuController.Money+=20000;
            MainMenuController.SaveData();
        }

         yield return new WaitForSeconds(2f);
            WinGame();
     }
    public void PauseGame(){
        if(pausePanel.activeSelf==false){
            FindObjectOfType<AudioManager>().Play("clickAudio");
            Time.timeScale = 0f;
            pausePanel.SetActive(true);
            blurCanvas.SetActive(true);
        }
        else{
            Time.timeScale = 1f;
            FindObjectOfType<AudioManager>().Play("clickAudio");
            pausePanel.SetActive(false);
            blurCanvas.SetActive(false);
        }
        resumeButton.onClick.AddListener(()=>ResumeGame());
    }

    public void ResumeGame(){
        FindObjectOfType<AudioManager>().Play("clickAudio");
        Time.timeScale = 1f;
        pausePanel.SetActive(false);
        skillShopPanel.SetActive(false);
        blurCanvas.SetActive(false);
        shopPanel.SetActive(false);
    }

    public void BackToMenu(){
        Time.timeScale = 1f;
        FindObjectOfType<AudioManager>().Play("clickAudio");
         SceneManager.LoadScene("LevelMenu");
    }
    public void Shop(){
        FindObjectOfType<AudioManager>().Play("clickAudio");
        Time.timeScale = 0f;
        shopPanel.SetActive(true);
        blurCanvas.SetActive(true);
    }
    /// lose game function
    public void LoseGame(){
            Time.timeScale = 0f;
            losePanel.SetActive(true);
            blurCanvas.SetActive(true);
    }
    public void RePlay(){
        FindObjectOfType<AudioManager>().Play("clickAudio");
        Scene m_Scene;
        m_Scene = SceneManager.GetActiveScene();
        Time.timeScale=1f;
        SceneManager.LoadScene(m_Scene.name);
    }


    //win game function
    public void WinGame(){
        Time.timeScale = 0f;
        winPanel.SetActive(true);
        blurCanvas.SetActive(true);
    }
    public void NextLevel(){
        FindObjectOfType<AudioManager>().Play("clickAudio");
        Scene m_Scene;
        m_Scene = SceneManager.GetActiveScene();
        Time.timeScale=1f;
        string currentlv = m_Scene.name.Substring(5);
        int crlv =int.Parse(currentlv);
        if(crlv<5){
            int nex = crlv+1;
            string a = "Level"+nex;
            Debug.Log(a);
            SceneManager.LoadScene(a);
        }
    }

    // show item using _ Panel
    public void ArmorPanelOpen(){
        if(armorItemPanel.activeSelf == false){
            armorItemPanel.SetActive(true);
            hpItemPanel.SetActive(false);
            swordItemPanel.SetActive(false);

        }
        else{
            armorItemPanel.SetActive(false);
        }
    }
    public void SwordPanelOpen(){
        if(swordItemPanel.activeSelf == false){
            armorItemPanel.SetActive(false);
            hpItemPanel.SetActive(false);
            swordItemPanel.SetActive(true);

        }
        else{
            swordItemPanel.SetActive(false);
        }

    }
    public void HpPanelOpen(){
        if(hpItemPanel.activeSelf == false){
            armorItemPanel.SetActive(false);
            hpItemPanel.SetActive(true);
            swordItemPanel.SetActive(false);

        }
        else{
            hpItemPanel.SetActive(false);
        }

    }
    public void CloseItemPanel(){
        
        hpItemPanel.SetActive(false);
        armorItemPanel.SetActive(false);
        swordItemPanel.SetActive(false);
    }

}
