using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    [SerializeField] float shieldLife = 30f;

    private float currentShieldLife;

    public bool InContactShield { get; private set; }

    private void OnTriggerEnter(Collider other)
    {
        InContactShield = true;
    }

    private void OnTriggerExit(Collider other)
    {
        InContactShield = false;
    }

}
