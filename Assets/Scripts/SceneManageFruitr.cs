using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerFruit : MonoBehaviour
{
    public void PlayGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("FruitNinja");
    }

        public void ExitGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameSelection");
    }
}
