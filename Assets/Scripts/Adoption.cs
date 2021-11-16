using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Adoption : MonoBehaviour
{
    [SerializeField] private List<GameObject> pets;

    //WitchDog
    public void SelectDogOne()
    {
        pets[0].SetActive(true);
        pets[1].SetActive(false);
        pets[2].SetActive(false);
        pets[3].SetActive(false);
    }
    public void SelectDogTow()
    {
        pets[0].SetActive(false);
        pets[1].SetActive(true);
        pets[2].SetActive(false);
        pets[3].SetActive(false);
    }
    public void SelectCatOne()
    {
        pets[0].SetActive(false);
        pets[1].SetActive(false);
        pets[2].SetActive(true);
        pets[3].SetActive(false);
    }
    public void SelectCatTwo()
    {
        pets[0].SetActive(false);
        pets[1].SetActive(false);
        pets[2].SetActive(false);
        pets[3].SetActive(true);
    }
}
