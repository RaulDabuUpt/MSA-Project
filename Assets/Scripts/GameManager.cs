using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public Image fadeImage;
    public Button restartButton;
    public Button exitButton;

    public Image pauseButton;
    public Image resumeButton;

    private Blade blade;
    private Spawner spawner;

    private Timer timer;

    public AudioSource audioSource;
    public AudioClip explosionSound;
    public AudioClip sliceSound;

    public AudioSource backgroundMusic;
    public AudioClip backgroundMusicClip;

    public TextMeshProUGUI comboText;


    public int score;
    private bool isPaused = false;

    private void Awake()
    {
        blade = FindObjectOfType<Blade>();
        spawner = FindObjectOfType<Spawner>();
        timer = FindObjectOfType<Timer>();
    }

    private void Start()
    {
        NewGame();

    }

    public void StartBackgroundMusic()
    {
        if (backgroundMusic != null && backgroundMusicClip != null)
        {
            backgroundMusic.clip = backgroundMusicClip;
            backgroundMusic.loop = true;
            backgroundMusic.Play();
        }
        else
        {
            Debug.LogError("Background music source or clip not assigned!");
        }
    }

    public void StopBackgroundMusic()
    {
        if (backgroundMusic != null)
        {
            backgroundMusic.Stop();
        }
    }

    public void NewGame()
    {
        Time.timeScale = 1f;

        blade.enabled = true;
        spawner.enabled = true;

        score = 0;
        scoreText.text = score.ToString();
        pauseButton.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(false);
        exitButton.gameObject.SetActive(false);
        if (timer != null)
        {
            timer.ResetTimer();
        }

        StartBackgroundMusic();

    }

    private void ClearScene()
    {
        Fruit[] fruits = FindObjectsOfType<Fruit>();
        foreach (Fruit fruit in fruits)
        {
            Destroy(fruit.gameObject);
        }
        Bomb[] bombs = FindObjectsOfType<Bomb>();
        foreach (Bomb bomb in bombs)
        {
            Destroy(bomb.gameObject);
        }
    }

    public void IncreaseScore(int comboCount)
    {
        if (comboCount >= 3)
        {
            Debug.Log("Score before combo: " + score);
            score += (comboCount * 2);
            Debug.Log("Score: " + score);
            ShowComboText(comboCount);

        }
        else if ( comboCount > 0 && comboCount <= 2)
        {
            score+= comboCount;
        }

        scoreText.text = score.ToString();
        blade.ClearCombo();
    }

    private void ShowComboText(int comboCount)
    {
        if (comboText != null)
        {
            comboText.text = "Combo " + comboCount + "!!!";
            comboText.gameObject.SetActive(true);
            StartCoroutine(HideComboText());
        }
    }

    private IEnumerator HideComboText()
    {
        yield return new WaitForSeconds(1f);
        if (comboText != null)
        {
            comboText.gameObject.SetActive(false);
        }
    }

    public void Explode()
    {
        blade.enabled = false;
        spawner.enabled = false;
        StopBackgroundMusic();
        StartCoroutine(ExplodeSequence());
    }

    public void TimeRunsOut()
    {
        blade.enabled = false;
        spawner.enabled = false;
        StopBackgroundMusic();
        StartCoroutine(GameOver());
    }

    private IEnumerator ExplodeSequence()
    {
        float elapsed = 0f;
        float duration = 0.5f;
        while (elapsed < duration)
        {
            float t = Mathf.Clamp01(elapsed / duration);
            fadeImage.color = Color.Lerp(Color.clear, Color.white, t);
            
            Time.timeScale = 1f - t;
            elapsed += Time.unscaledDeltaTime;

            yield return null;
        }
        ClearScene();
        pauseButton.gameObject.SetActive(false);
        resumeButton.gameObject.SetActive(false);

        if (audioSource != null && explosionSound != null)
        {
            audioSource.PlayOneShot(explosionSound);
        }

        yield return new WaitForSecondsRealtime(1f);

        

        elapsed = 0f;

        while (elapsed < duration)
        {
            float t = Mathf.Clamp01(elapsed / duration);
            fadeImage.color = Color.Lerp(Color.white, Color.clear, t);

            elapsed += Time.unscaledDeltaTime;

            yield return null;
        }
        
        
        restartButton.gameObject.SetActive(true);
        exitButton.gameObject.SetActive(true);
    }

    private IEnumerator GameOver()
    {
        yield return new WaitForSecondsRealtime(1f);
        pauseButton.gameObject.SetActive(false);
        resumeButton.gameObject.SetActive(false);
        ClearScene();
        restartButton.gameObject.SetActive(true);
        exitButton.gameObject.SetActive(true);
    }

   

    public void TogglePause()
    {
        if (isPaused)
        {
            Time.timeScale = 1f;
            isPaused = false;
            resumeButton.gameObject.SetActive(false);
            pauseButton.gameObject.SetActive(true);
        }
        else
        {
            Time.timeScale = 0f;
            isPaused = true;
            pauseButton.gameObject.SetActive(false);
            resumeButton.gameObject.SetActive(true);
        }
    }


    public void PlaySliceSound()
    {
        if (audioSource != null && sliceSound != null)
        {
            audioSource.PlayOneShot(sliceSound);
        }
    }
        public void exitGame()
    {
        SceneManager.LoadScene("GameSelection");
    }
}
