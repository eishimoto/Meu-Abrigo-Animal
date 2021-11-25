using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICanvas : MonoBehaviour
{
    [Header("Collections")]
    [SerializeField] private List<GameObject> rooms;
    [SerializeField] private List<GameObject> pets;
    [SerializeField] private List<GameObject> stats;

    //Ui and canvas
    [Header("Panels")]
    [SerializeField] private GameObject petsSelection;
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject store;
    [SerializeField] private GameObject book;
    [SerializeField] private GameObject mixPills;
    [SerializeField] private GameObject socialInsta;
    [SerializeField] private GameObject calendar;
    [SerializeField] private GameObject ConfirmExit;
    [SerializeField] private GameObject adoptionPanel;

    //Vectors to move objects out of view
    [Header("Postition change")]
    [SerializeField] private Vector2 onScreen;
    [SerializeField] private Vector2 onScreen2;
    [SerializeField] private Vector2 onScreen3;
    [SerializeField] private Vector2 onScreen4;
    [SerializeField] private Vector2 onScreenStats;
    [SerializeField] private Vector2 offScreen;
    [SerializeField] private Vector2 offScreen2;
    [SerializeField] private Vector2 offScreen3;


    private int index = 0;
    private int indexSafe;
    //static
    public static bool canUseTool = true;
    public static bool on, on2, on3,on4;
    public static bool runTime;
    public static bool touchInteraction;

    private void Start()
    {
        RoomZero();
        runTime = false;
        touchInteraction = true;
    }

    private void Update()
    {
        SelectionOfPet(); 
    }
    private void SelectionOfPet()
    {
        if (index < 4)
        {
            indexSafe = index;
        }

        if (index == 0)
        {
            pets[0].transform.position = onScreen;
            pets[1].transform.position = offScreen;
            pets[2].transform.position = offScreen2;
            pets[3].transform.position = offScreen3;
            on = true;
            on2 = false;
            on3 = false;
            on4 = false;
            stats[0].transform.position = onScreenStats;
        }
        if (index == 1)
        {
            pets[0].transform.position = offScreen;
            pets[1].transform.position = onScreen2;
            pets[2].transform.position = offScreen2;
            pets[3].transform.position = offScreen3;
            on = false;
            on2 = true;
            on3 = false;
            on4 = false;
            stats[1].transform.position = onScreenStats;

        }
        if (index == 2)
        {
            pets[0].transform.position = offScreen;
            pets[1].transform.position = offScreen2;
            pets[2].transform.position = onScreen3;
            pets[3].transform.position = offScreen3;
            on = false;
            on2 = false;
            on3 = true;
            on4 = false;
            stats[2].transform.position = onScreenStats;
        }
        if (index == 3)
        {
            pets[0].transform.position = offScreen;
            pets[1].transform.position = offScreen2;
            pets[2].transform.position = offScreen3;
            pets[3].transform.position = onScreen4;
            on = false;
            on2 = false;
            on3 = false;
            on4 = true;
            stats[3].transform.position = onScreenStats;
        }
    }
    //UI
    public void Menu()
    {
        menu.SetActive(true);
        runTime = false;
        canUseTool = false;
        touchInteraction = false;
    }

    public void CloseMenu()
    {
        menu.SetActive(false);
        runTime = true;
        canUseTool = true;
        touchInteraction = true;
    }

    public void ExitApplication()
    {
        Application.Quit();
    }
    public void ConfirmExitPanel()
    {
        ConfirmExit.SetActive(true);
        touchInteraction = false;
    }
    public void CloseConfirmExitPanel()
    {
        ConfirmExit.SetActive(false);
        touchInteraction = true;
    }


    public void Social()
    {
        petsSelection.SetActive(true);
        canUseTool = false;
        touchInteraction = false;
    }

    public void CloseSocial()
    {
        petsSelection.SetActive(false);
        index = indexSafe;
        canUseTool = true;
        touchInteraction = true;
    }

    public void Book()
    {
        book.SetActive(true);
        canUseTool = false;
        touchInteraction = false;
    }
    public void CloseBook()
    {
        book.SetActive(false);
        canUseTool = true;
        touchInteraction = true;
    }

    public void Store()
    {
        store.SetActive(true);
        canUseTool = false;
        touchInteraction = false;
    }
    public void CloseStore()
    {
        store.SetActive(false);
        canUseTool = true;
        touchInteraction = true;
    }
    public void Pill()
    {
        mixPills.SetActive(true);
        touchInteraction = false;
    }

    public void ClosePill()
    {
        MixPills.instance.PillAsset();
        mixPills.SetActive(false);
        touchInteraction = true;
    }

    public void SocialInsta()
    {
        socialInsta.SetActive(true);
        canUseTool = false;
        touchInteraction = false;
    }

    public void CloseSocialInsta()
    {
        socialInsta.SetActive(false);
        canUseTool = true;
        touchInteraction = true;
    }

    public void Calendar()
    {
        calendar.SetActive(true);
        canUseTool = false;
        touchInteraction = false;
    }

    public void CloseCalendar()
    {
        calendar.SetActive(false);
        canUseTool = true;
        touchInteraction = true;
    }

    public void AdoptionPanel()
    {
        adoptionPanel.SetActive(true);

    }
    public void CloseAdoptionPanel()
    {
        adoptionPanel.SetActive(false);
    }
    //PETS
    public void PetOne()
    {
        index = 0;
        canUseTool = true;
        petsSelection.SetActive(false);
        touchInteraction = true;
    }

    public void PetTwo()
    {
        index = 1;
        canUseTool = true;
        petsSelection.SetActive(false);
        touchInteraction = true;
    }

    public void PetTheer()
    {
        index = 2;
        canUseTool = true;
        petsSelection.SetActive(false);
        touchInteraction = true;
    }
    public void PetFour()
    {
        index = 3;
        canUseTool = true;
        petsSelection.SetActive(false);
        touchInteraction = true;
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