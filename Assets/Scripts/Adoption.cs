using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Adoption : MonoBehaviour
{
    [SerializeField] private List<GameObject> pets;
    [SerializeField] private List<GameObject> petsButtons;

    public static bool DogOnScene = true, Dog2OnScene, CatOnScene, Cat2OnScene;
    private void Update()
    {
        CheckIfIsSick();
    }

    private void CheckIfIsSick()
    {
        if (Stats.sick)
        {
            //pets[0].SetActive(false);
            petsButtons[0].SetActive(false);
        }
        else if(!Stats.sick)
        {
            petsButtons[0].SetActive(true);
        }
        if (Stats2.sick)
        {
           //pets[2].SetActive(false);
            petsButtons[2].SetActive(false);
        }
        else if (!Stats2.sick)
        {
            petsButtons[2].SetActive(true);
        }
        if (Stats3.sick)
        {
            //pets[1].SetActive(false);
            petsButtons[1].SetActive(false);
        }
        else if (!Stats3.sick)
        {
            petsButtons[1].SetActive(true);
        }
        if (Stats4.sick)
        {
            //pets[3].SetActive(false);
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
    public void SelectDogTow()
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
}
