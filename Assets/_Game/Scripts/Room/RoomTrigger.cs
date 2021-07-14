using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTrigger : MonoBehaviour
{
    [SerializeField] Room room = default;
    [SerializeField] GameObject[] roomObjects = default;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            //room.ActivateRoom();

            for (int i = 0; i < roomObjects.Length; i++)
            {
                roomObjects[i].SetActive(true);
            }

            this.gameObject.SetActive(false);
        }

        //for(int i = 0; i < roomObjects.Length; i++)
        //{
        //    roomObjects[i].SetActive(true);
        //}

        //this.gameObject.SetActive(false);
    }
}
