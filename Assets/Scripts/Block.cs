using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    // config params
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockSparklesVFX;
    [SerializeField] int maxHits = 1;
    [SerializeField] Sprite[] hitSprites;

    // cached references
    [SerializeField] LevelState levelState;

    // state
    [SerializeField] int timesHit = 0; // serialized for debugging

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "Breakable")
        {
            timesHit++;
            if (timesHit >= maxHits)
            {
                DestroyBlock();
            }
            else
            {
                ShowNextHitSprite();
            }
        }
    }

    private void ShowNextHitSprite()
    {
        // not safe!
        int spriteIndex = timesHit - 1;
        GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
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
