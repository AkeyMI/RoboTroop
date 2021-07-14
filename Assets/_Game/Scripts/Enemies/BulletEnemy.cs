using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : MonoBehaviour
{
    [SerializeField] float speed = 8f;

    private int damage;
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Init(int amount)
    {
        damage = amount;
    }

    private void Start()
    {
        rb.velocity = transform.forward * speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Player Hit");
        if (other.CompareTag("Player"))
        {
            other.GetComponent<CharacterController>().Damage(damage);
        }

        Destroy(this.gameObject);
    }
}
