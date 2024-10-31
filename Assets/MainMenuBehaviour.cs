using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuBehaviour : MonoBehaviour
{
    public CanvasGroup OptionPanel;

    public void PlayGame() {
        SceneManager.LoadScene("TitleScene");
    }
    public void Options(){
        OptionPanel.alpha = 1;
        OptionPanel.blocksRaycasts = true;
    }
    public void Back(){
        OptionPanel.alpha = 0;
        OptionPanel.blocksRaycasts = false;
    }
    public void Quit(){
        Application.Quit();
    }


}
