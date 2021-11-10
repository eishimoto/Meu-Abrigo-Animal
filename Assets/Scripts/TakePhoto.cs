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

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CatPostPhoto()
    {
        GameObject cat = Instantiate(catPhotoPrefab[0], new Vector3(0, 0, 0), Quaternion.identity);
        cat.transform.SetParent(parent, false);
    }
    public void Cat2PostPhoto()
    {
        GameObject cat2 = Instantiate(cat2PhotoPrefab[0], new Vector3(0, 0, 0), Quaternion.identity);
        cat2.transform.SetParent(parent, false);
    }
    public void DogPostPhoto()
    {
        GameObject dog = Instantiate(dogPhotoPrefab[0], new Vector3(0, 0, 0), Quaternion.identity);
        dog.transform.SetParent(parent, false);
    }
    public void Dog2PostPhoto()
    {
        GameObject dog2 = Instantiate(dog2PhotoPrefab[0], new Vector3(0, 0, 0), Quaternion.identity);
        dog2.transform.SetParent(parent, false);
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

