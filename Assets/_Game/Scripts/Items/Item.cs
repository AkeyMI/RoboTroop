using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item_Name", menuName = "RoboTroop/Item", order = 1)]
public class Item : ScriptableObject
{
    [SerializeField] string itemName;
    [SerializeField] string description;
    [SerializeField] Type type = default;

    public Type Type => type;

    [SerializeField] Effect[] effects;

    public void Use()
    {
        for (int i = 0; i < effects.Length; i++)
        {
            effects[i].Apply();
        }
    }

    public virtual void Take()
    {
        PoolManager.Instance.ChangeItem(this);
    }
}
