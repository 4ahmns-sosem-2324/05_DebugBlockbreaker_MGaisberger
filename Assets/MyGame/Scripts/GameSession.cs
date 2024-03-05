using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;
using System;

public class GameSession:MonoBehaviour{

    //config parameters
    [Range(0.1f, 10f)] public float gameSpeed = 1f;
    public int pointsPerBlockDestroyed = 83;
    public TextMeshProUGUI scoreText;
    public bool isAutoPlayEnabled;
    

    //state variables
    public int currentScore = 0;

    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameSession>().Length;
        if (gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private object FindObjectsOfType<T>()
    {
        throw new NotImplementedException();
    }

    public void Start()
    {
        scoreText.text = currentScore.ToString();
    }

    public void Update () 
    {
        Time.timeScale = gameSpeed;
	}

    public void AddToScore()
    {
        currentScore += pointsPerBlockDestroyed;
        scoreText.text = currentScore.ToString();
    }

    public void ResetGame()
    {
        Destroy (gameObject);
    }

    public bool IsAutoPlayEnabled()
    {
        return isAutoPlayEnabled;
    }
}
