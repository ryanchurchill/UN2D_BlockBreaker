using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene("Scenes/Game Over");
        //Debug.Log("Collider hit by " + collision.ToString() + " with transform " + collision.transform.position);
    }
}
