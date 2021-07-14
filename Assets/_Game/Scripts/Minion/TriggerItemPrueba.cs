using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerItemPrueba : MonoBehaviour
{


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            other.GetComponent<ItemMinionPrueba>().UseItem();
            Debug.Log("Si reconocio el item");
        }
    }
}
