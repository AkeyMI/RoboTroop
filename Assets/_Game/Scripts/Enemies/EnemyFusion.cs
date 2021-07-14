using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyFusion_Name", menuName = "RoboTroop/EnemyFusion", order = 1)]
public class EnemyFusion : ScriptableObject
{
    public EnemyStats[] enemyFusionStats;
}
