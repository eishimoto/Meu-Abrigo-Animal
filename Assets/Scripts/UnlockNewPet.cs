using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockNewPet : MonoBehaviour
{
    [SerializeField] private List<GameObject> catOne;
    [SerializeField] private List<GameObject> catTwo;
    [SerializeField] private List<GameObject> dogTwo;
    [SerializeField] private GameObject newPet;

    private void Update()
    {
        UnlockPets();
    }

    private void UnlockPets()
    {
        if (Timer.day == 1)
        {
            for (int i = 0; i < catOne.Count; i++)
            {
                catOne[i].SetActive(true);
            }
        }

        if (Timer.day == 2)
        {
            for (int i = 0; i < catOne.Count; i++)
            {
                catTwo[i].SetActive(true);
            }
        }

        if (Timer.day == 3)
        {
            for (int i = 0; i < catOne.Count; i++)
            {
                dogTwo[i].SetActive(true);
            }
        }
    }
}
