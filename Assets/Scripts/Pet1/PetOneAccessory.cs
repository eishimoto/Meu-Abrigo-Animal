using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetOneAccessory : MonoBehaviour
{
    [SerializeField] private List<GameObject> accessories;

    public void Ballon()
    {
        if (accessories[0].activeInHierarchy == false)
        {
            accessories[0].SetActive(true);
        }
        else
        {
            accessories[0].SetActive(false);
        }
    }
    public void Tie()
    {
        if (accessories[1].activeInHierarchy == false)
        {
            accessories[1].SetActive(true);
            accessories[2].SetActive(false);
            accessories[3].SetActive(false);
            accessories[4].SetActive(false);
            accessories[5].SetActive(false);
        }
        else
        {
            accessories[1].SetActive(false);
            accessories[2].SetActive(false);
            accessories[3].SetActive(false);
            accessories[4].SetActive(false);
            accessories[5].SetActive(false);
        }
    }
    public void TieYellow()
    {
        if (accessories[2].activeInHierarchy == false)
        {
            accessories[1].SetActive(false);
            accessories[2].SetActive(true);
            accessories[3].SetActive(false);
            accessories[4].SetActive(false);
            accessories[5].SetActive(false);
        }
        else
        {
            accessories[1].SetActive(false);
            accessories[2].SetActive(false);
            accessories[3].SetActive(false);
            accessories[4].SetActive(false);
            accessories[5].SetActive(false);
        }
    }
    public void TieBlue()
    {
        if (accessories[3].activeInHierarchy == false)
        {
            accessories[1].SetActive(false);
            accessories[2].SetActive(false);
            accessories[3].SetActive(true);
            accessories[4].SetActive(false);
            accessories[5].SetActive(false);
        }
        else
        {
            accessories[1].SetActive(false);
            accessories[2].SetActive(false);
            accessories[3].SetActive(false);
            accessories[4].SetActive(false);
            accessories[5].SetActive(false);
        }
    }
    public void TieRed()
    {
        if (accessories[4].activeInHierarchy == false)
        {
            accessories[1].SetActive(false);
            accessories[2].SetActive(false);
            accessories[3].SetActive(false);
            accessories[4].SetActive(true);
            accessories[5].SetActive(false);
        }
        else
        {
            accessories[1].SetActive(false);
            accessories[2].SetActive(false);
            accessories[3].SetActive(false);
            accessories[4].SetActive(false);
            accessories[5].SetActive(false);
        }
    }
    public void TiePurple()
    {
        if (accessories[5].activeInHierarchy == false)
        {
            accessories[1].SetActive(false);
            accessories[2].SetActive(false);
            accessories[3].SetActive(false);
            accessories[4].SetActive(false);
            accessories[5].SetActive(true);
        }
        else
        {
            accessories[1].SetActive(false);
            accessories[2].SetActive(false);
            accessories[3].SetActive(false);
            accessories[4].SetActive(false);
            accessories[5].SetActive(false);
        }
    }
    public void Hat()
    {
        if (accessories[6].activeInHierarchy == false)
        {
            accessories[6].SetActive(true);
        }
        else
        {
            accessories[6].SetActive(false);
        }
    }
    public void Monacle()
    {
        if (accessories[7].activeInHierarchy == false)
        {
            accessories[7].SetActive(true);
        }
        else
        {
            accessories[7].SetActive(false);
        }
    }
    public void Teeth()
    {
        if (accessories[8].activeInHierarchy == false)
        {
            accessories[8].SetActive(true);
        }
        else
        {
            accessories[8].SetActive(false);
        }
    }
    public void EyePatch()
    {
        if (accessories[9].activeInHierarchy == false)
        {
            accessories[9].SetActive(true);
        }
        else
        {
            accessories[9].SetActive(false);
        }
    }
    public void Collar()
    {
        if (accessories[10].activeInHierarchy == false)
        {
            accessories[10].SetActive(true);
        }
        else
        {
            accessories[10].SetActive(false);
        }
    }
    public void Walker()
    {
        if (accessories[11].activeInHierarchy == false)
        {
            accessories[11].SetActive(true);
        }
        else
        {
            accessories[11].SetActive(false);
        }
    }

}
