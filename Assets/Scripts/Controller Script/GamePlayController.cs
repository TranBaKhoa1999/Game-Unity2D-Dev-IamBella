using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class GamePlayController : MonoBehaviour
{
    [SerializeField]
    private GameObject pausePanel;
    [SerializeField]
    private Button resumeButton;
    [SerializeField]
    private GameObject blurCanvas;
    [SerializeField]
    private GameObject shopPanel;
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
        blurCanvas.SetActive(false);
        shopPanel.SetActive(false);
    }

    public void BackToMenu(){
        Time.timeScale = 1f;
        Application.LoadLevel("LevelMenu");
    }
    public void Shop(){
        Time.timeScale = 0f;
        shopPanel.SetActive(true);
        blurCanvas.SetActive(true);
    }
}
