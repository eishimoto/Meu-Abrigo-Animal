using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetSounds : MonoBehaviour
{
    private AudioSource myAudioSource;
    [SerializeField] private List<AudioClip> audioClip;


    public static PetSounds instance;
    private void OnEnable()
    {
        if (instance = null)
        {
            instance = this;
        }
    }
    private void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
    }

    public IEnumerator DogBark()
    {
        yield return new WaitForSeconds(0.1f);
        myAudioSource.PlayOneShot(audioClip[0]);
    }

    public IEnumerator DogAngry()
    {
        yield return new WaitForSeconds(0.1f);
        myAudioSource.PlayOneShot(audioClip[3]);
    }
}
