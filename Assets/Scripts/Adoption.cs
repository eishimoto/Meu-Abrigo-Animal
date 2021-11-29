using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Adoption : MonoBehaviour
{
    //list for decoretion
    [SerializeField] private List<GameObject> pets;
    [SerializeField] private List<GameObject> shadows;
    [SerializeField] private List<GameObject> petsButtons;

    //list for Final Panel
    [SerializeField] private GameObject lasPanel;
    [SerializeField] private List<Transform> postitions;

    public static bool DogOnScene, Dog2OnScene, CatOnScene, Cat2OnScene;
    private void Update()
    {
        CheckIfIsSick();
    }

    private void CheckIfIsSick()
    {
        if (Stats.sick)
        {
            petsButtons[0].SetActive(false);
        }
        else if(!Stats.sick)
        {
            petsButtons[0].SetActive(true);
        }

        if (Stats2.sick)
        {
            petsButtons[2].SetActive(false);
        }
        else if (!Stats2.sick)
        {
            petsButtons[2].SetActive(true);
        }

        if (Stats3.sick)
        {
            petsButtons[1].SetActive(false);
        }
        else if (!Stats3.sick)
        {
            petsButtons[1].SetActive(true);
        }

        if (Stats4.sick)
        {
            petsButtons[3].SetActive(false);
        }
        else if (!Stats4.sick)
        {
            petsButtons[3].SetActive(true);
        }
    }
    //WitchDog
    public void SelectDogOne()
    {
        pets[0].SetActive(true);
        pets[1].SetActive(false);
        pets[2].SetActive(false);
        pets[3].SetActive(false);
        DogOnScene = true;
        Dog2OnScene = false;
        CatOnScene = false;
        Cat2OnScene = false;
    }
    public void SelectDogTwo()
    {
        pets[0].SetActive(false);
        pets[1].SetActive(true);
        pets[2].SetActive(false);
        pets[3].SetActive(false);
        DogOnScene = false;
        Dog2OnScene = true;
        CatOnScene = false;
        Cat2OnScene = false;
    }
    public void SelectCatOne()
    {
        pets[0].SetActive(false);
        pets[1].SetActive(false);
        pets[2].SetActive(true);
        pets[3].SetActive(false);
        DogOnScene = false;
        Dog2OnScene = false;
        CatOnScene = true;
        Cat2OnScene = false;
    }
    public void SelectCatTwo()
    {
        pets[0].SetActive(false);
        pets[1].SetActive(false);
        pets[2].SetActive(false);
        pets[3].SetActive(true);
        DogOnScene = false;
        Dog2OnScene = false;
        CatOnScene = false;
        Cat2OnScene = true;
    }

    public void LastAction()
    {
        lasPanel.SetActive(true);

        for (int i = 0; i < pets.Count; i++)
        {
            pets[i].SetActive(true);
        }

        if (petsButtons[0].activeInHierarchy)
        {
            pets[0].transform.SetParent(postitions[2], false); // dog 1
            shadows[1].SetActive(true);
        }

        if (petsButtons[1].activeInHierarchy)
        {
            pets[1].transform.SetParent(postitions[3], false); // dog 2
            shadows[0].SetActive(true);
        }
        if (petsButtons[2].activeInHierarchy)
        {
            pets[2].transform.SetParent(postitions[0], false); // cat 1
            shadows[2].SetActive(true);
        }
        if (petsButtons[3].activeInHierarchy)
        {
            pets[3].transform.SetParent(postitions[1], false); // cat 2
            shadows[3].SetActive(true);
        }
    }
}
