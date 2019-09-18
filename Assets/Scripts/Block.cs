using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip breakSound;
    [SerializeField] LevelState levelState;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        destroyBlock();
    }

    private void Start()
    {

    }

    private void destroyBlock()
    {
        if (breakSound != null)
        {
            // Udemy uses Camera.main.transform.position
            // TODO: silence ball sound
            AudioSource.PlayClipAtPoint(breakSound, transform.position);
        }
        FindObjectOfType<LevelState>().onBlockDestroy();
        Destroy(gameObject);
    }
}
