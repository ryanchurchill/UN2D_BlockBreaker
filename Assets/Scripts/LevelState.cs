using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelState : MonoBehaviour
{
    // objects for designer to set
    [SerializeField] TextMeshProUGUI scoreText;

    // state
    
    // serialized for debugging
    [SerializeField] int remainingBlockCount = 0;


    int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        CountBlocks();
        setScore(score); // so scoreText updates
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CountBlocks()
    {
        remainingBlockCount = FindObjectsOfType<Block>().Length;
    }

    // Not a true event, we just call this from block, that's why it's public
    public void onBlockDestroy()
    {
        remainingBlockCount--;
        setScore(score + 1);
        if (remainingBlockCount == 0)
        {
            FindObjectOfType<SceneLoader>().LoadNextScene();
        }
    }

    private void setScore(int newScore)
    {
        score = newScore;
        scoreText.text = score.ToString();
    }
}
