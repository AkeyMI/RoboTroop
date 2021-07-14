using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Minion_Name", menuName = "RoboTroop/MinionData", order = 1)]
public class MinionData : ScriptableObject
{
    public GameObject minionPrefab = default;
    public string minionName = default;
    public GameObject buttonPrefab = default;
    public Type type = default;

    public int life = 3;
    public int damage = 1;
}
