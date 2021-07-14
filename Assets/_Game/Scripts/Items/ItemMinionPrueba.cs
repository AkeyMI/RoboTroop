using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMinionPrueba : MonoBehaviour
{
    [SerializeField] Item item = default;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            UseItem();
        }
    }

    public void UseItem()
    {
        item.Use();
        Destroy(this.gameObject);
    }
}
