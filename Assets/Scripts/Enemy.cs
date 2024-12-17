using System;
using UnityEngine;
using UnityEngine.Serialization;
using Object = System.Object;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject enemyExplosionVFX;
    
    private void OnParticleCollision(GameObject other)
    {
        Instantiate(enemyExplosionVFX, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
