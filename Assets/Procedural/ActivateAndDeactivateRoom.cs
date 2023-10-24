using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateAndDeactivateRoom : MonoBehaviour
{
    public GameObject nextRoom;
    public GameObject[] otherRooms;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            nextRoom.SetActive(true);
            foreach (var room in otherRooms)
            {
                room.SetActive(false);
            }
        }
    }
}
