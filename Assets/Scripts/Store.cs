using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Store : MonoBehaviour
{
    [SerializeField] private GameObject foodPanel;
    [SerializeField] private GameObject toolsPanel;
    [SerializeField] private GameObject medecinePanel;
    [SerializeField] private GameObject accerssoryPanel;
    [SerializeField] private List<Image> buttons;
    [SerializeField] private List<Sprite> lightSprite;
    public void Start()
    {
        buttons[0].sprite = lightSprite[0];
    }
    public void ChangeStore(int index)
    {
        if (index == 0)
        {
            toolsPanel.SetActive(false);
            foodPanel.SetActive(true);
            medecinePanel.SetActive(false);
            accerssoryPanel.SetActive(false);
            buttons[0].sprite = lightSprite[0];
            buttons[1].sprite = lightSprite[1];
            buttons[2].sprite = lightSprite[1];
            buttons[3].sprite = lightSprite[1];
        }
        if (index == 1)
        {
            toolsPanel.SetActive(true);
            foodPanel.SetActive(false);
            medecinePanel.SetActive(false);
            accerssoryPanel.SetActive(false);
            buttons[0].sprite = lightSprite[1];
            buttons[1].sprite = lightSprite[0];
            buttons[2].sprite = lightSprite[1];
            buttons[3].sprite = lightSprite[1];
        }
        if (index == 2)
        {
            toolsPanel.SetActive(false);
            foodPanel.SetActive(false);
            medecinePanel.SetActive(true);
            accerssoryPanel.SetActive(false);
            buttons[0].sprite = lightSprite[1];
            buttons[1].sprite = lightSprite[1];
            buttons[2].sprite = lightSprite[0];
            buttons[3].sprite = lightSprite[1];
        }
        if(index == 3)
        {
            toolsPanel.SetActive(false);
            foodPanel.SetActive(false);
            medecinePanel.SetActive(false);
            accerssoryPanel.SetActive(true);
            buttons[0].sprite = lightSprite[1];
            buttons[1].sprite = lightSprite[1];
            buttons[2].sprite = lightSprite[1];
            buttons[3].sprite = lightSprite[0];
        }
    }
}
