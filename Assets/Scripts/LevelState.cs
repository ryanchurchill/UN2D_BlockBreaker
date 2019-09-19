using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//TODO: should be split into Level and Game states
public class LevelState : MonoBehaviour
{
    // cached objects
    GameState gameState;

    // state
    
    // serialized for debugging
    [SerializeField] int remainingBlockCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        gameState = FindObjectOfType<GameState>();
        CountBlocks();
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
        gameState.incrementScore();
        if (remainingBlockCount == 0)
        {
            FindObjectOfType<SceneLoader>().LoadNextScene();
        }
    }

    
}
