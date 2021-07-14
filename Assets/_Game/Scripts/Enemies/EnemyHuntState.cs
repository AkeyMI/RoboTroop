using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHuntState : EnemyBaseState
{
    private EnemyController enemyController;
    private float speed;
    private Vector3 newDirection;
    private Vector3 newPosition;
    private bool thereIsNotPLayer;
    private Collider playercol;

    public override void EnterState(EnemyController enemy)
    {
        enemyController = enemy;
        Debug.Log("Entro en caza");
    }

    public override void Update(EnemyController enemy)
    {
        PlayerIsCloseToAttack();
        //PlayerStillClose();
        WereIsThePLayer();

        //if(!thereIsNotPLayer)
        //{
        //    HuntingPLayer(playercol);
        //}

        HuntingPLayer(playercol);
    }

    private void WereIsThePLayer()
    {
        CharacterController player = enemyController.LocatePLayer();

        playercol = player.GetComponent<Collider>();
    }

    //private void PlayerStillClose()
    //{
    //    Collider[] players = Physics.OverlapSphere(enemyController.transform.position, enemyController.Stats.distanceHunt);

    //    foreach (var player in players)
    //    {
    //        if (player.CompareTag("Player"))
    //        {
    //            playercol = player;
    //            thereIsNotPLayer = false;
    //            break;
    //        }
    //        else
    //        {
    //            thereIsNotPLayer = true;
    //        }
    //    }

    //    if(thereIsNotPLayer)
    //    {
    //        enemyController.TransitionToState(enemyController.PatrolState);
    //    }
    //}

    private void PlayerIsCloseToAttack()
    {
        Collider[] players = Physics.OverlapSphere(enemyController.transform.position, enemyController.Stats.distanceAttack);

        foreach (var player in players)
        {
            if (player.CompareTag("Player"))
            {
                ChangeToAttack();
            }
        }
    }

    private void ChangeToAttack()
    {
        if(enemyController.Stats.type == enemyController.Shoot)
        {
            enemyController.TransitionToState(enemyController.AttackDistanceState);
        }
        else if(enemyController.Stats.type == enemyController.Tank || enemyController.Stats.type == enemyController.Ninja)
        {
            enemyController.TransitionToState(enemyController.AttackMeleeState);
        }
    }

    private void HuntingPLayer(Collider player)
    {
        speed = enemyController.Stats.speed * Time.deltaTime;
        newPosition = player.transform.position;
        newPosition.y = enemyController.transform.position.y;
        newDirection = newPosition - enemyController.transform.position;
        enemyController.transform.LookAt(newPosition);
        enemyController.transform.position += newDirection * speed;
    }
}
