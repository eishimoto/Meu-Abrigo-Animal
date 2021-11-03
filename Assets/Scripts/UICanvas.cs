using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICanvas : MonoBehaviour
{
    //arrays
    [Header("Collections")]
    [SerializeField] private List<GameObject> rooms;
    [SerializeField] private List<GameObject> pets;
    [SerializeField] private GameObject[] stats;

    //Ui and canvas
    [Header("Panels")]
    [SerializeField] private GameObject petsSelection;
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject adoption;
    [SerializeField] private GameObject store;
    [SerializeField] private GameObject book;
    [SerializeField] private GameObject mixPills;
    [SerializeField] private GameObject socialInsta;

    //Vectors to move objects out of view
    [Header("Postition change")]
    [SerializeField] private Vector2 onScreen;
    [SerializeField] private Vector2 onScreenStats;
    [SerializeField] private Vector2 offScreen;

    private int index = 0;
    private int indexSafe;

    //static
    public static bool canUseTool = true;

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
            pets[3].transform.position = offScreen;

            stats[0].SetActive(true);
            stats[1].SetActive(false);
            stats[2].SetActive(false);
            stats[3].SetActive(false);
        }
        if (index == 1)
        {
            pets[0].transform.position = offScreen;
            pets[1].transform.position = onScreen;
            pets[2].transform.position = offScreen;
            pets[3].transform.position = offScreen;

            stats[0].SetActive(false);
            stats[1].SetActive(true);
            stats[2].SetActive(false);
            stats[3].SetActive(false);
        }
        if (index == 2)
        {
            pets[0].transform.position = offScreen;
            pets[1].transform.position = offScreen;
            pets[2].transform.position = onScreen;
            pets[3].transform.position = offScreen;

            stats[0].SetActive(false);
            stats[1].SetActive(false);
            stats[2].SetActive(true);
            stats[3].SetActive(false);
        }
        if (index == 3)
        {
            pets[0].transform.position = offScreen;
            pets[1].transform.position = offScreen;
            pets[2].transform.position = offScreen;
            pets[3].transform.position = onScreen;

            stats[0].SetActive(false);
            stats[1].SetActive(false);
            stats[2].SetActive(false);
            stats[3].SetActive(true);
        }
    }

    //UI
    public void Menu()
    {
        menu.SetActive(true);
        Time.timeScale = 0;
        canUseTool = false;
    }

    public void CloseMenu()
    {
        menu.SetActive(false);
        Time.timeScale = 1;
        canUseTool = true;
    }

    public void ExitApplication()
    {
        Application.Quit();
    }

    public void Social()
    {
        petsSelection.SetActive(true);
        canUseTool = false;
    }

    public void CloseSocial()
    {
        petsSelection.SetActive(false);
        index = indexSafe;
        canUseTool = true;
    }

    public void Book()
    {
        book.SetActive(true);
        canUseTool = false;
    }
    public void CloseBook()
    {
        book.SetActive(false);
        canUseTool = true;
    }

    public void Store()
    {
        store.SetActive(true);
        canUseTool = false;
    }
    public void CloseStore()
    {
        store.SetActive(false);
        canUseTool = true;
    }

    public void Adoption()
    {
        adoption.SetActive(true);
        canUseTool = false;
        FillSlot.instance.SpwanAllpet();
    }

    public void CloseAdoption()
    {
        FillSlot.instance.DestoyPets();
        adoption.SetActive(false);
        canUseTool = true;
    }

    public void Pill()
    {
        mixPills.SetActive(true);
    }

    public void ClosePill()
    {
        MixPills.instance.PillAsset();
        mixPills.SetActive(false);
    }

    public void SocialInsta()
    {
        socialInsta.SetActive(true);
        canUseTool = false;
    }

    public void CloseSocialInsta()
    {
        socialInsta.SetActive(false);
        canUseTool = true;
    }


    //PETS
    public void PetOne()
    {
        index = 0;
        canUseTool = true;
        petsSelection.SetActive(false);
    }

    public void PetTwo()
    {
        index = 1;
        canUseTool = true;
        petsSelection.SetActive(false);
    }

    public void PetTheer()
    {
        index = 2;
        canUseTool = true;
        petsSelection.SetActive(false);
    }
    public void PetFour()
    {
        index = 3;
        canUseTool = true;
        petsSelection.SetActive(false);
    }

    //ChangeRooms
    public void RoomZero()
    {
        rooms[0].SetActive(true);
        rooms[1].SetActive(false);
        rooms[2].SetActive(false);
        rooms[3].SetActive(false);
        rooms[4].SetActive(false);
    }

    public void RoomOne()
    {
        rooms[0].SetActive(false);
        rooms[1].SetActive(true);
        rooms[2].SetActive(false);
        rooms[3].SetActive(false);
        rooms[4].SetActive(false);
    }

    public void RoomTwo()
    {
        rooms[0].SetActive(false);
        rooms[1].SetActive(false);
        rooms[2].SetActive(true);
        rooms[3].SetActive(false);
        rooms[4].SetActive(false);
    }

    public void RoomThree()
    {
        rooms[0].SetActive(false);
        rooms[1].SetActive(false);
        rooms[2].SetActive(false);
        rooms[3].SetActive(true);
        rooms[4].SetActive(false);
    }

    public void RoomFour()
    {
        rooms[0].SetActive(false);
        rooms[1].SetActive(false);
        rooms[2].SetActive(false);
        rooms[3].SetActive(false);
        rooms[4].SetActive(true);
    }
}

