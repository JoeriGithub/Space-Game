using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RoomBehaviour : MonoBehaviour
{
    public GameObject[] doors;
    public GameObject[] walls;
    public GameObject floor;

    public bool[] TestStatus;

    public void UpdateRoom(bool[] status)
    {
        for (int i = 0; i < status.Length; i++)
        {
            doors[i].SetActive(status[i]);
            walls[i].SetActive(!status[i]);
        }

        if (status.Any(x => x))
        {
            ColorFloor();
        }
    }

    void ColorFloor()
    { 
        floor.GetComponent<Renderer>().material.color = Color.red;
    }

}
