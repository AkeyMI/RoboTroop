using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Effect_Name", menuName = "RoboTroop/Effects/ItemDistance", order = 1)]
public class ItemDistance : Item
{
    public GameObject bullet = default;
    public float timeForAttack = 0.5f;
    public int ammo = 5;
    public float timeToReload = 1f;
    public int damage = 1;
}
