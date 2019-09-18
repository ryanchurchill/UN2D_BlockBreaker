using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelState : MonoBehaviour
{
    [SerializeField] // for debugging
    int remainingBlockCount = 0;

    // Start is called before the first frame update
    void Start()
    {
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
        if (remainingBlockCount == 0)
        {
            FindObjectOfType<SceneLoader>().LoadNextScene();
        }
    }
}
