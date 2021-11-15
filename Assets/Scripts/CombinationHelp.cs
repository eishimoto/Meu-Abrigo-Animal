using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombinationHelp : MonoBehaviour
{
    [SerializeField] private GameObject help;

    public void ShowCombinationHelp()
    {
        help.SetActive(true);
    }

}
