using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public int score;
    public Text text_score;
    public Text text_finalScore;
    public GameObject InGame;
    public GameObject End;

    //GameManager Instance화
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();
                if (instance == null)
                {
                    GameObject singleton = new GameObject("GameManager");
                    instance = singleton.AddComponent<GameManager>();
                }
            }

            return instance;
        }
    }

    void Start()
    {
        score = 0;
        PopScore();
    }

    public void IncreaseScore()
    {
        score++;
        PopScore();
    }

    void PopScore()
    {
        text_score.text = "x " + score;
    }

    public void GameOver()
    {
        InGame.SetActive((false));
        End.SetActive((true));
        
        PopFinalScore();
    }

    void PopFinalScore()
    {
        text_finalScore.text = "Score: " + score;
    }
}
