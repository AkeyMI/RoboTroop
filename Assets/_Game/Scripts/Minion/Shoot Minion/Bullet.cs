using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
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
        if(other.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyController>().Damage(damage);
            Destroy(this.gameObject);
            Debug.Log("Enemy Hit");
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
