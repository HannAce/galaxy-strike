using System;
using UnityEngine;
using Object = System.Object;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject explosionVFX;
    
    private void OnParticleCollision(GameObject other)
    {
        Instantiate(explosionVFX, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
