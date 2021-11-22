using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialOrder : MonoBehaviour
{
    [SerializeField] private GameObject HelpPanel;
    [SerializeField] private List<GameObject> grupText;
        

    private void OnEnable()
    {

    }
    void Update()
    {
        
    }

    public void OpenHelpPanel()
    {
        HelpPanel.SetActive(true);
    }
    public void CloseHelpPanel()
    {
        HelpPanel.SetActive(false);
    }
}
