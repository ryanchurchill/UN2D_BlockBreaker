using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

	public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadStartScene()
    {
        // reset game state
        GameState gameState = FindObjectOfType<GameState>();
        if (gameState != null)
        {
            Debug.Log("hello");
            // better to call public method on gameState that destroys itself?
            Destroy(gameState.gameObject);
        }

        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
