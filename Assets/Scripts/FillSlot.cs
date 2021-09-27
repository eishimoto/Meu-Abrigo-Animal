using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillSlot : MonoBehaviour
{
    [SerializeField] GameObject[] petPrefab;
    [SerializeField] Transform[] slots;

    private GameObject PetPrefab, PetPrefabOne, PetPrefabTwo, PetPrefabTheer;

    public static FillSlot instance;

    public void OnEnable()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        
    }

    private void Update()
    {

    }

    public void SpwanAllpet()
    {
        int petZero = Random.Range(0, petPrefab.Length);
        int petOne  = Random.Range(0, petPrefab.Length);
        int petTwo = Random.Range(0, petPrefab.Length);
        //int petThree = Random.Range(0, petPrefab.Length);

        if (slots[0].childCount != 0|| slots[1].childCount != 0 || slots[2].childCount != 0) //|| slots[3].childCount != 0)
        {
            SpwanAllpet();
            return;
        }
            PetPrefab = Instantiate(petPrefab[petZero], slots[0]);
            PetPrefabOne = Instantiate(petPrefab[petOne], slots[1]);
            PetPrefabTwo = Instantiate(petPrefab[petTwo], slots[2]);
            //PetPrefabTheer = Instantiate(petPrefab[petThree], slots[3]);
    }

    public void DestoyPets()
    {
        Destroy(PetPrefab);
        Destroy(PetPrefabOne);
        Destroy(PetPrefabTwo);
       // Destroy(PetPrefabTheer);
    }
}
