using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Adoption : MonoBehaviour
{
    [SerializeField] private List<GameObject> pets;

    public static bool DogOnScene = true, Dog2OnScene, CatOnScene, Cat2OnScene;
    private void Update()
    {

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
