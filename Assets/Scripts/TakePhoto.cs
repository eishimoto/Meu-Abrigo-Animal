using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TakePhoto : MonoBehaviour
{
    [SerializeField] private List<GameObject> catPhotoPrefab;
    [SerializeField] private List<GameObject> cat2PhotoPrefab;
    [SerializeField] private List<GameObject> dogPhotoPrefab;
    [SerializeField] private List<GameObject> dog2PhotoPrefab;

    [SerializeField] private GameObject whitchPet;
    [SerializeField] private Transform parent;
    [SerializeField] private GameObject flashGameObject;
    [SerializeField] private List<Button> flashSound;

    //text
    [SerializeField] private TextMeshProUGUI text;
    private int followers;

    //private
    private int random;

    public static int petValue;
    public static TakePhoto instance;
    private void OnEnable()
    {
        if(instance = null)
        {
            instance = this;
        }
        followers = 50;
        text.text = (followers.ToString() + " Seguidores");
    }
    private void Start()
    {
        petValue = 0;
    }
    private void Update()
    {
        RestPetValue();
        Debug.Log(petValue);
    }
    public void CatPostPhoto()
    {
        if (petValue <= 3)
        {
            random = Random.Range(0, 6);
            GameObject cat = Instantiate(catPhotoPrefab[random], new Vector3(0, 0, 0), Quaternion.identity);
            cat.transform.SetParent(parent, false);
            petValue++;
            Money.instance.AddMoneyPhoto(10);
            flashGameObject.SetActive(true);
        }
    }
    public void Cat2PostPhoto()
    {
        if (petValue <= 3)
        {
            random = Random.Range(0, 6);
            GameObject cat2 = Instantiate(cat2PhotoPrefab[random], new Vector3(0, 0, 0), Quaternion.identity);
            cat2.transform.SetParent(parent, false);
            petValue++;
            Money.instance.AddMoneyPhoto(10);
            flashGameObject.SetActive(true);
        }
    }
    public void DogPostPhoto()
    {
        if (petValue <= 3)
        {
            random = Random.Range(0, 6);
            GameObject dog = Instantiate(dogPhotoPrefab[random], new Vector3(0, 0, 0), Quaternion.identity);
            dog.transform.SetParent(parent, false);
            petValue++;
            Money.instance.AddMoneyPhoto(10);
            flashGameObject.SetActive(true);
        }
    }
    public void Dog2PostPhoto()
    {
        if(petValue <= 3)
        {
            random = Random.Range(0, 6);
            GameObject dog2 = Instantiate(dog2PhotoPrefab[random], new Vector3(0, 0, 0), Quaternion.identity);
            dog2.transform.SetParent(parent, false);
            petValue++;
            Money.instance.AddMoneyPhoto(10);
            flashGameObject.SetActive(true);
        }
    }

    public void RestPetValue()
    {
        if(Timer.resetPhotoValue)
        { 
            if(petValue == 4)
            {
                Timer.value += 5;
                followers += 10;
                text.text = (followers.ToString() + " Seguidores");
            }

            petValue = 0;
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

