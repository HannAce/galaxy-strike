using System;
using UnityEngine;
using UnityEngine.Serialization;
using Object = System.Object;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject enemyExplosionVFX;
    [SerializeField] private int hp = 3;
    [SerializeField] private int scoreValue = 10;
    
    private Scoreboard scoreboard;
    
    private void Start()
    {
        scoreboard = FindFirstObjectByType<Scoreboard>();
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    private void ProcessHit()
    {
        hp--;

        if (hp <= 0)
        {
            scoreboard.IncreaseScore(scoreValue);
            Instantiate(enemyExplosionVFX, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
