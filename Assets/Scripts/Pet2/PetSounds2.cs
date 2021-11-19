using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetSounds2 : MonoBehaviour
{
    private AudioSource myAudioSource;
    [SerializeField] private List<AudioClip> audioClip;


    public static PetSounds2 instance;
    private void OnEnable()
    {
        if(instance = null)
        {
            instance = this;
        }
    }
    private void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
    }

    public IEnumerator CatMeow()
    {
        yield return new WaitForSeconds(0.5f);
        myAudioSource.PlayOneShot(audioClip[0]);
    }

    public IEnumerator CatAngry()
    {
        yield return new WaitForSeconds(0.5f);
        myAudioSource.PlayOneShot(audioClip[3]);
    }
}
