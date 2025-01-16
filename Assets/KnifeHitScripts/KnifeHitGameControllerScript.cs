using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(KnifeHitGameUI))]
public class KnifeHitGameControllerScript : MonoBehaviour
{
    public static KnifeHitGameControllerScript Instance { get; private set; }

    private int initialKnifeCount = 2;
    private int knifeCount;

    [SerializeField]
    private Vector2 knifeSpawnPosition;
    [SerializeField]
    private GameObject knifeObject;

    public KnifeHitGameUI GameUI { get; private set; }


    private int _score = 0;
    [SerializeField]
    private Text scoreLabel;

    private void Awake()
    {
        Instance = this;
        GameUI = GetComponent<KnifeHitGameUI>();
    }

    private void Start()
    {
        InitializeGame();
    }

    private void InitializeGame()
    {
        knifeCount = PlayerPrefs.GetInt("KnifeCount", initialKnifeCount);
        _score = PlayerPrefs.GetInt("Score", 0);

        // Update the score UI
        scoreLabel.text = "Score: " + _score;
        GameUI.SetInitialDisplayedKnifeCount(knifeCount);
        SpawnKnife();
    }

    public void OnSuccesfulKnifeHit()
    {
        _score++;
        scoreLabel.text = "Score: " + _score;
        if (knifeCount > 0)
        {
            SpawnKnife();
        }
        else
        {
            StartGameOverSequence(true);
        }
    }

    private void SpawnKnife()
    {
        knifeCount--;
        Instantiate(knifeObject, knifeSpawnPosition, Quaternion.identity);
    }

    public void StartGameOverSequence(bool win)
    {
        StartCoroutine(GameOverSequenceCoroutine(win));
    }

    private IEnumerator GameOverSequenceCoroutine(bool win)
    {
        if (win)
        {
            PlayerPrefs.SetInt("Score", _score);
            yield return new WaitForSecondsRealtime(0.3f);
            int newKnifeCount = PlayerPrefs.GetInt("KnifeCount", initialKnifeCount) + 1;
            PlayerPrefs.SetInt("KnifeCount", newKnifeCount);

            RestartGame();
        }
        else
        {
            PlayerPrefs.SetInt("KnifeCount", initialKnifeCount);
            PlayerPrefs.SetInt("Score", 0);
            GameUI.ShowRestartButton();
            GameUI.ShowExitButton();
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
    }
        public void ExitGame()
    {
        SceneManager.LoadScene("GameSelection");
    }
}
