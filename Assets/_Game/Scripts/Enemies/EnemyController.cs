using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour, IDamagable
{
    [SerializeField] Type shoot = default;
    [SerializeField] Type tank = default;
    [SerializeField] Type ninja = default;
    [SerializeField] GameObject spawnPointBullet = default;

    public Type Shoot => shoot;
    public Type Tank => tank;
    public Type Ninja => ninja; 

    [SerializeField] EnemyFusion enemyFusionStats = default;
    private EnemyStats currentStats;

    public Rigidbody Rb => rb;
    public EnemyStats Stats => currentStats;

    public Vector3 PositionSpawn => positionSpawn;

    private EnemyBaseState currentState;
    private EnemyBaseState currentAttackState;
    private Rigidbody rb;
    private Vector3 positionSpawn;
    private int life;
    private float timeToChangeType = 6f;

    //public readonly EnemyPatrolState PatrolState = new EnemyPatrolState();
    public readonly EnemyHuntState HuntState = new EnemyHuntState();
    public readonly EnemyDistanceAttackState AttackDistanceState = new EnemyDistanceAttackState();
    public readonly EnemyMeleeAttackState AttackMeleeState =  new EnemyMeleeAttackState();

    private void Start()
    {
        currentStats = enemyFusionStats.enemyFusionStats[0];
        life = currentStats.life;
        rb = GetComponent<Rigidbody>();
        ChangeSpawnPoint(this.gameObject.transform.position);
        TransitionToState(HuntState);
    }

    private void Update()
    {
        currentState.Update(this);
        CountDownToChangeType();
    }

    public void TransitionToState(EnemyBaseState state)
    {
        currentState = state;
        currentState.EnterState(this);
    }

    public void ChangeSpawnPoint(Vector3 vec)
    {
        positionSpawn = new Vector3(vec.x, vec.y, vec.z);
    }

    private void ChangeEnemyType()
    {
        int amount = Random.Range(0, enemyFusionStats.enemyFusionStats.Length);

        currentStats = enemyFusionStats.enemyFusionStats[amount];
    }

    private void CountDownToChangeType()
    {
        if(timeToChangeType > 0)
        {
            timeToChangeType -= Time.deltaTime;
        }
        else
        {
            ChangeEnemyType();
            timeToChangeType = 6f;
        }
    }

    public CharacterController LocatePLayer()
    {
        CharacterController player = FindObjectOfType<CharacterController>();

        return player;
    }

    public void CreateBullet()
    {
        GameObject bullet = Instantiate(currentStats.bullet, spawnPointBullet.transform.position, spawnPointBullet.transform.rotation);
        bullet.GetComponent<BulletEnemy>().Init(currentStats.damage);
    }

    public void Damage(int amount)
    {
        life -= amount;

        if(life <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
