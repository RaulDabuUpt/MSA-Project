using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void playGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("KnifeHitGame");
    }
}
