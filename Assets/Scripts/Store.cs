using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Store : MonoBehaviour
{
    [SerializeField] private GameObject toolsPanel;
    [SerializeField] private GameObject foodPanel;
    [SerializeField] private GameObject accerssoryPanel;

    public void ChangeStore(int index)
    {
        if (index == 0)
        {
            toolsPanel.SetActive(true);
            foodPanel.SetActive(false);
            accerssoryPanel.SetActive(false);
        }
        if (index == 1)
        {
            toolsPanel.SetActive(false);
            foodPanel.SetActive(true);
            accerssoryPanel.SetActive(false);
        }
        if (index == 2)
        {
            toolsPanel.SetActive(false);
            foodPanel.SetActive(false);
            accerssoryPanel.SetActive(true);
        }
    }
}
