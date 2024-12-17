using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] private GameObject[] lasers;
    
    private bool isFiring = false;

    private void Update()
    {
        ProcessFiring();
    }

    private void ProcessFiring()
    {
        foreach (GameObject laser in lasers)
        {
            ParticleSystem.EmissionModule emissionModule = laser.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = isFiring;
        }
    }

    public void OnFire(InputValue value)
    {
        isFiring = value.isPressed; // this will auto set back to false when not pressed due to the input system "Press And Release"
    }
}
