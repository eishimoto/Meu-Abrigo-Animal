using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockNewPet : MonoBehaviour
{
    [SerializeField] private List<GameObject> catOne;
    [SerializeField] private List<GameObject> catTwo;
    [SerializeField] private List<GameObject> dogTwo;
    [SerializeField] private List<GameObject> newPet;

    private void Update()
    {
        StartCoroutine(UnlockPets());
    }

    IEnumerator UnlockPets()
    {
        yield return new WaitForSeconds(6f);
        if (Timer.day == 1)
        {
            for (int i = 0; i < catOne.Count; i++)
            {
                catOne[i].SetActive(true);
            }
            newPet[0].SetActive(true);
        }

        if (Timer.day == 2)
        {
            for (int i = 0; i < catOne.Count; i++)
            {
                dogTwo[i].SetActive(true);
            }
            newPet[2].SetActive(true);
        }

        if (Timer.day == 3)
        {
            for (int i = 0; i < catOne.Count; i++)
            {
                catTwo[i].SetActive(true);
            }
            newPet[1].SetActive(true);
        }
    }

    public void DestoryNewPet()
    {
        Destroy(newPet[0]);
    }
    public void DestoryNewPet2()
    {
        Destroy(newPet[1]);
    }
    public void DestoryNewPet3()
    {
        Destroy(newPet[2]);
    }
}
