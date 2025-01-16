using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenuBehaviour : MonoBehaviour
{
    public CanvasGroup OptionPanel;

    public void PlayGame1() {
        SceneManager.LoadScene("TitleScene");
    }
        public void PlayGame2() {
        SceneManager.LoadScene("TitleScene 1");
    }
        public void PlayGame3() {
        SceneManager.LoadScene("KnifeHitMainMenu");
    }
        public void PlayGame4() {
        SceneManager.LoadScene("TitleScene 3");
    }
        public void PlayGame5() {
        SceneManager.LoadScene("TitleScene 4");
    }
        public void PlayGame6() {
        SceneManager.LoadScene("Main Menu");
    }
    public void Back() {
        SceneManager.LoadScene("MainMenu");
    }
    public void Quit(){
        Application.Quit();
    }


}