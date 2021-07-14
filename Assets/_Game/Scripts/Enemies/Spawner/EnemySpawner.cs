using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab = default;


    private void Start()
    {
        NextEnemy();
    }

    IEnumerator TimeToSpawn()
    {
        yield return new WaitForSeconds(8f);

        Instantiate(enemyPrefab, this.transform.position, Quaternion.identity);

        NextEnemy();
    }

    private void NextEnemy()
    {
        StartCoroutine("TimeToSpawn");
    }
}
