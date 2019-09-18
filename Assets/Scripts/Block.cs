using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip breakSound;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (breakSound != null)
        {
            // Udemy uses Camera.main.transform.position
            AudioSource.PlayClipAtPoint(breakSound, transform.position);
        }
        Destroy(gameObject);
    }
}
