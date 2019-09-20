using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip breakSound;
    [SerializeField] LevelState levelState;
    [SerializeField] GameObject blockSparklesVFX;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "Breakable")
        {
            DestroyBlock();
        }
    }

    private void Start()
    {

    }

    private void DestroyBlock()
    {
        TriggerParticlesVFX();
        if (breakSound != null)
        {
            // Udemy uses Camera.main.transform.position
            // TODO: silence ball sound
            AudioSource.PlayClipAtPoint(breakSound, transform.position);
        }
        FindObjectOfType<LevelState>().onBlockDestroy();
        Destroy(gameObject);
    }

    private void TriggerParticlesVFX()
    {
        GameObject sparkles = Instantiate(blockSparklesVFX, transform.position, transform.rotation);
        Destroy(sparkles, 2f);
    }
}
