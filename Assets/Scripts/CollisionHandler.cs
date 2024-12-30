using System;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] private GameObject playerExplosionVFX;
    
    [SerializeField] private GameManager gameManager;

    private void Awake()
    {
     
    }

    private void OnTriggerEnter(Collider other)
    {
        Instantiate(playerExplosionVFX, transform.position, Quaternion.identity);
        Destroy(gameObject);
        gameManager.ReloadLevel();
    }
}
