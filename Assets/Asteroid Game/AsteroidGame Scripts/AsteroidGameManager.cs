using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AsteroidGameManager : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreUI;
    [SerializeField] private GameObject gameOverUI;

    int score = 0;

    public void AddPoints(int points)
    {
        score += points;
        scoreUI.text = score.ToString();
    }

    public void SetGameOver()
    {
        gameOverUI.SetActive(true);
    }
}
