using System;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] private GameObject playerExplosionVFX;

    private void Awake()
    {
     
    }

    private void OnTriggerEnter(Collider other)
    {
        Instantiate(playerExplosionVFX, transform.position, Quaternion.identity);
        Destroy(gameObject);
        GameManager.Instance.EndGame(false);
    }
}
