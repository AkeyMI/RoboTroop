using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolState : EnemyBaseState
{
    private EnemyController enemyController;
    private Vector3 positionSpawn;
    private Vector3 newPosition;
    private Vector3 newDirection;
    private bool itsNotInThePosition;
    private float timeBetweenMavesInPatrol;
    private float speed;


    public override void EnterState(EnemyController enemy)
    {
        enemyController = enemy;
        positionSpawn = enemy.PositionSpawn;
        newPosition = enemy.gameObject.transform.position;
        timeBetweenMavesInPatrol = enemyController.Stats.timeBetweenMovesInPatrol;
        Debug.Log("Entro en patrulla");
    }

    public override void Update(EnemyController enemy)
    {
        ThereIsAPLayerClose();
        CheckIfCanMove();
        MoveEnemy();
    }

    private Vector3 CreateRandomPosition()
    {
        float x = Random.Range(positionSpawn.x - enemyController.Stats.distancePatrol, positionSpawn.x + enemyController.Stats.distancePatrol);
        float z = Random.Range(positionSpawn.z - enemyController.Stats.distancePatrol, positionSpawn.z + enemyController.Stats.distancePatrol);

        return new Vector3(x, 0f, z);
    }

    private void ThereIsAPLayerClose()
    {
        Collider[] players = Physics.OverlapSphere(enemyController.transform.position, enemyController.Stats.distanceHunt);

        foreach(var player in players)
        {
            if(player.CompareTag("Player"))
            {
                enemyController.TransitionToState(enemyController.HuntState);
            }
        }
    }

    private void MoveEnemy()
    {
        if(itsNotInThePosition)
        {
            speed = enemyController.Stats.speed * Time.deltaTime;
            enemyController.transform.LookAt(newPosition);
            enemyController.transform.position += newDirection * speed;
        }
        else
        {
            //Debug.Log("No se deveria estar moviendo");
        }
    }

    private void CheckIfCanMove()
    {
        //Debug.Log(Vector3.Distance(enemyController.transform.position, newPosition));

        if (Vector3.Distance(enemyController.transform.position, newPosition) <= 1)
        {
            newDirection = new Vector3(0,0,0);
            itsNotInThePosition = false;
            CountToNextMove();
            //Debug.Log("esta funcionando");
        }
        else
        {
            itsNotInThePosition = true;
        }
    }

    private void CountToNextMove()
    {
        if(timeBetweenMavesInPatrol > 0 && !itsNotInThePosition)
        {
            timeBetweenMavesInPatrol -= Time.deltaTime;
        }
        else
        {
            timeBetweenMavesInPatrol = enemyController.Stats.timeBetweenMovesInPatrol;
            GetNewDirection();
        }
    }

    private void GetNewDirection()
    {
        newPosition = CreateRandomPosition();
        newPosition.y = enemyController.transform.position.y;

        newDirection = newPosition - enemyController.transform.position;
        itsNotInThePosition = true;
    }
}
