using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    //array
    [SerializeField] private GameObject[] rooms;
    [SerializeField] private GameObject[] pets;

    //single
    [SerializeField] private GameObject social;
    [SerializeField] private GameObject menu;

    private int index = 0;
    private int indexSafe;

    private void Start()
    {
        
    }

    private void Update()
    {
        SelectionOfPet();
    }
    private void SelectionOfPet()
    {
        if (index < 3)
        {
            indexSafe = index;
        }

        if (index == 0)
        {
            pets[0].SetActive(true);
            pets[1].SetActive(false);
            pets[2].SetActive(false);
        }
        if (index == 1)
        {
            pets[0].SetActive(false);
            pets[1].SetActive(true);
            pets[2].SetActive(false);
        }
        if (index == 2)
        {
            pets[0].SetActive(false);
            pets[1].SetActive(false);
            pets[2].SetActive(true);
        }
        if (index == 3)
        {
            pets[0].SetActive(false);
            pets[1].SetActive(false);
            pets[2].SetActive(false);
        }
    }

    public void Social()
    {
        index = 3;
        social.SetActive(true);
    }

    public void CloseSocial()
    {
        social.SetActive(false);
        index = indexSafe;
    }

    public void PetOne()
    {
        index = 0;
        social.SetActive(false);
    }

    public void PetTwo()
    {
        index = 1;
        social.SetActive(false);
    }

    public void PetTheer()
    {
        index = 2;
        social.SetActive(false);
    }

    //ChangeRooms
    public void RoomZero()
    {
        rooms[0].SetActive(true);
        rooms[1].SetActive(false);
        rooms[2].SetActive(false);
        rooms[3].SetActive(false);
    }

    public void RoomOne()
    {
        rooms[0].SetActive(false);
        rooms[1].SetActive(true);
        rooms[2].SetActive(false);
        rooms[3].SetActive(false);
    }

    public void RoomTwo()
    {
        rooms[0].SetActive(false);
        rooms[1].SetActive(false);
        rooms[2].SetActive(true);
        rooms[3].SetActive(false);
    }

    public void RoomThree()
    {
        rooms[0].SetActive(false);
        rooms[1].SetActive(false);
        rooms[2].SetActive(false);
        rooms[3].SetActive(true);
    }
}
