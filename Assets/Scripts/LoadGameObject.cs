using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadGameObject : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Invoke("DisableGameObject", 1f);
    }
    private void DisableGameObject()
    {
        gameObject.SetActive(false);
    }
}
