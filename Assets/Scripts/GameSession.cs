using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameSession : MonoBehaviour
    
{
    [SerializeField] int playerLives = 3;
    [SerializeField] int score = 0;

    [SerializeField] TextMeshProUGUI livesText;
    [SerializeField] TextMeshProUGUI scoreText;

    // Start is called before the first frame update
    void Awake()
    {
        int numGameSession = FindObjectsOfType<GameSession>().Length;
        if(numGameSession > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

     void Start()
    {
        livesText.text = playerLives.ToString();
        scoreText.text = score.ToString();
        
    }

    // Update is called once per frame
    public void ProcessPlayer()
    {
        if(playerLives > 1)
        {
            TakeLife();
        }
        else
        {
            ResetGamesSession();
        }
        void ResetGamesSession()
        {
            SceneManager.LoadScene(0);
            Destroy(gameObject);
        }
    }
    public void AddToScore(int pointsToAdd)
    {
        score += pointsToAdd;
        scoreText.text = score.ToString();
    }

    void TakeLife()
    {
        playerLives--;
        int currentScenIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScenIndex);
        livesText.text = playerLives.ToString();
    }
}
