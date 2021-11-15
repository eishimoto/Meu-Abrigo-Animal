using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TakePhoto : MonoBehaviour
{
    [SerializeField] private List<GameObject> catPhotoPrefab;
    [SerializeField] private List<GameObject> cat2PhotoPrefab;
    [SerializeField] private List<GameObject> dogPhotoPrefab;
    [SerializeField] private List<GameObject> dog2PhotoPrefab;

    [SerializeField] private GameObject whitchPet;
    [SerializeField] private Transform parent;


    public static int catValue1, catValue2, dogValue1, dogValue2;
    public static TakePhoto instance;
    private void OnEnable()
    {
        if(instance = null)
        {
            instance = this;
        }
    }
    private void Update()
    {
        RestPetValue();
    }
    public void CatPostPhoto()
    {
        if (catValue1 <= 2)
        {
            GameObject cat = Instantiate(catPhotoPrefab[0], new Vector3(0, 0, 0), Quaternion.identity);
            cat.transform.SetParent(parent, false);
            catValue1++;
            Money.instance.AddMoneyPhoto(10);
        }
    }
    public void Cat2PostPhoto()
    {
        if (catValue2 <= 2)
        {
            GameObject cat2 = Instantiate(cat2PhotoPrefab[0], new Vector3(0, 0, 0), Quaternion.identity);
            cat2.transform.SetParent(parent, false);
            catValue2++;
            Money.instance.AddMoneyPhoto(10);
        }
    }
    public void DogPostPhoto()
    {
        if (dogValue1 <= 2)
        {
            GameObject dog = Instantiate(dogPhotoPrefab[0], new Vector3(0, 0, 0), Quaternion.identity);
            dog.transform.SetParent(parent, false);
            dogValue1++;
            Money.instance.AddMoneyPhoto(10);
        }
    }
    public void Dog2PostPhoto()
    {
        if(dogValue2 <= 2)
        {
            GameObject dog2 = Instantiate(dog2PhotoPrefab[0], new Vector3(0, 0, 0), Quaternion.identity);
            dog2.transform.SetParent(parent, false);
            dogValue2++;
            Money.instance.AddMoneyPhoto(10);
        }
    }

    public void RestPetValue()
    {
        if(Timer.resetPhotoValue)
        {
            catValue1 = 0;
            catValue2 = 0;
            dogValue1 = 0;
            dogValue2 = 0;
            Timer.resetPhotoValue = false;
        }
    }

    public void WhitchPetToTakePhoto()
    {
        whitchPet.SetActive(true);
    }
    public void CloseWhitchPetToTakePhoto()
    {
        whitchPet.SetActive(false);
    }
}

