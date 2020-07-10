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
    //end
    void FixedUpdate() {
        if(Moving.isDie == true){
            StartCoroutine("PlayerDie");
        }

    }
    private IEnumerator PlayerDie() // hàm delay thời gian bắn đạn
     {        
         yield return new WaitForSeconds(2f);
            LoseGame();
     }
    public void PauseGame(){
        if(pausePanel.activeSelf==false){
            Time.timeScale = 0f;
            pausePanel.SetActive(true);
            blurCanvas.SetActive(true);
        }
        else{
            Time.timeScale = 1f;
            pausePanel.SetActive(false);
            blurCanvas.SetActive(false);
        }
        resumeButton.onClick.AddListener(()=>ResumeGame());
    }

    public void ResumeGame(){
        Time.timeScale = 1f;
        pausePanel.SetActive(false);
        skillShopPanel.SetActive(false);
        blurCanvas.SetActive(false);
        shopPanel.SetActive(false);
    }

    public void BackToMenu(){
        Time.timeScale = 1f;
         SceneManager.LoadScene("LevelMenu");
    }
    public void Shop(){
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
        Scene m_Scene;
        m_Scene = SceneManager.GetActiveScene();
        Time.timeScale=1f;
        string currentlv = m_Scene.name.Substring(5);
        int crlv;
        int.TryParse(m_Scene.name, out crlv);
        if(crlv<5){
            SceneManager.LoadScene("Level"+crlv+1);
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
