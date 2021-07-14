using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Effect_Name", menuName = "RoboTroop/Effects/TakeMinionEffect", order = 1)]
public class TakeMinionEffect : Effect
{
    [SerializeField] MinionData minionData = default;

    public override void Apply()
    {
        PoolManager.Instance.CreateMinion(minionData.minionPrefab, minionData.buttonPrefab, minionData.minionName);
    }

}
