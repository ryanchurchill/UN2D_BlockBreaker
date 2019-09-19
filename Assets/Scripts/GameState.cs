using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameState : MonoBehaviour
{
    // objects for designer to set
    [SerializeField] TextMeshProUGUI scoreText;

    // state
    int score = 0;

    // to make this a singleton
    private void Awake()
    {
        int levelStateCount = FindObjectsOfType<LevelState>().Length;
        //if (levelStateCount > 1)
        //{
        //    gameObject.SetActive(false); // bug fix from Rick, still sketchy. There's got to be a better way to implement a singleton..
        //    // destroy self
        //    Destroy(gameObject);
        //}
        //else
        //{
            DontDestroyOnLoad(gameObject);
        //}
    }

    // Start is called before the first frame update
    void Start()
    {
        setScore(score); // so scoreText updates
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void setScore(int newScore)
    {
        score = newScore;
        scoreText.text = score.ToString();
    }

    public void incrementScore()
    {
        setScore(score + 1);
    }

    //public void resetGame()
    //{
    //    Destroy(gameObject);
    //}
}
