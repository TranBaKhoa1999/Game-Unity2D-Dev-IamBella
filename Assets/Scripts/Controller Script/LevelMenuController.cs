using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMenuController : MonoBehaviour
{
    // Start is called before the first frame update
    public void BackButtonOnClick(){
        Application.LoadLevel("MainMenu");
    }
    public void PlayLevel1Onlick(){
        Application.LoadLevel("Level1");
    }
    public void PlayLevel2Onlick(){
        Application.LoadLevel("Level2");
    }
}
