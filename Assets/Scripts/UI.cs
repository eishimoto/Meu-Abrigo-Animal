using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    //arrays
    [SerializeField] private GameObject[] rooms;
    [SerializeField] private GameObject[] pets;
    [SerializeField] private GameObject[] stats;

    //Ui and canvas
    [SerializeField] private GameObject social;
    [SerializeField] private GameObject menu;

    //Vectors to move objects out of view
    [SerializeField] private Vector2 onScreen;
    [SerializeField] private Vector2 onScreenStats;
    [SerializeField] private Vector2 offScreen;

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
            pets[0].transform.position = onScreen;
            pets[1].transform.position = offScreen;
            pets[2].transform.position = offScreen;

            stats[0].transform.position = onScreenStats;
            stats[1].transform.position = offScreen;
            stats[2].transform.position = offScreen;
        }
        if (index == 1)
        {
            pets[0].transform.position = offScreen;
            pets[1].transform.position = onScreen;
            pets[2].transform.position = offScreen;

            stats[0].transform.position = offScreen;
            stats[1].transform.position = onScreenStats;
            stats[2].transform.position = offScreen;
        }
        if (index == 2)
        {
            pets[0].transform.position = offScreen;
            pets[1].transform.position = offScreen;
            pets[2].transform.position = onScreen;

            stats[0].transform.position = offScreen;
            stats[1].transform.position = offScreen;
            stats[2].transform.position = onScreenStats;
        }
        if (index == 3)
        {
            pets[0].transform.position = offScreen;
            pets[1].transform.position = offScreen;
            pets[2].transform.position = offScreen;

            stats[0].transform.position = offScreen;
            stats[1].transform.position = offScreen;
            stats[2].transform.position = offScreen;
        }
    }

    public void Menu()
    {
        menu.SetActive(true);
        Time.timeScale = 0;
    }

    public void CloseMenu()
    {
        menu.SetActive(false);
        Time.timeScale = 1;
    }

    public void ExitApplication()
    {
        Application.Quit();
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
