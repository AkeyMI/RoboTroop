using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackMeleeTrigger : MonoBehaviour
{
    [SerializeField] CharacterController characterController = default;

    private List<GameObject> enemiesInArea;
    private Collider parentCollider;

    private void Start()
    {
        enemiesInArea = new List<GameObject>();
        parentCollider = transform.parent.parent.GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Enemy") || other.Equals(parentCollider)) return;

        AttackEnemiesInArea(other);
    }

    public void AttackEnemiesInArea(Collider other)
    {
        //Debug.Log("Se golpeo a: " + enemiesInArea.Count + " enemigos");
        Debug.Log("Se golpeo a un enemigo");

        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyController>().Damage(characterController.Data.damage);
        }
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (!other.CompareTag("Enemy") || other.Equals(parentCollider)) return;

    //    enemiesInArea.Add(other.gameObject);

    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    if (!other.CompareTag("Enemy") || other.Equals(parentCollider)) return;

    //    enemiesInArea.Remove(other.gameObject);
    //}
}
