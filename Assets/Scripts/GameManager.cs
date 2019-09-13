using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour
{


    public int startLives = 3;
    private int points = 0;
    public TextMeshPro scoreText;
    public LivesController livesController;

    string sceneName = "SampleScene";
    public GameObject gameOverSign;
    public GameObject input;

    CherryController cherryController;

    void OnEnable()
    {
        CherryController.OnCherryDeath += CherryDead;
        CherryController.OnCherrySaved += CherrySaved;
    }

    void OnDisable()
    {
        CherryController.OnCherryDeath -= CherryDead;
        CherryController.OnCherrySaved -= CherrySaved;
    }

    private void CherrySaved()
    {
        catchedTheCherry();
    }

    private void CherryDead()
    {
        if (!livesController.RemoveLife())
        {
            GameOver();
             
        }
    }

    public void GameOver()
    {
        
        gameOverSign.SetActive(true);
        input.SetActive(false);
        StopAllCoroutines();
    }

    void Start()
    {
        UpdateScoreLabel();
        livesController.InitiateLives(startLives);
        gameOverSign.SetActive(false);

    }

   
    public int Points()
    {
        return points;
    }

    void UpdateScoreLabel()
    {
        scoreText.text = points.ToString();
    }

    void catchedTheCherry()
    {
        points++;
        UpdateScoreLabel();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(sceneName);
    }
}
