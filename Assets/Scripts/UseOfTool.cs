using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UseOfTool : MonoBehaviour
{
    //private
    private SpriteRenderer _spriteRender;
    //collection
    [SerializeField] private List<Sprite> sprite = new List<Sprite>();
    //text
    [SerializeField] private TextMeshProUGUI textDisplay;
    [SerializeField] private int quantity;

    //bool
    public static bool cantMove;

    //static for function
    public static UseOfTool instance;
    private void OnEnable()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        _spriteRender = GetComponent<SpriteRenderer>();
        cantMove = false;
        UpdateTextMeshPro();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UseInStats()
    {
        Subtract();
        ChangeSprite();
        UpdateTextMeshPro();
    }

    public void ChangeSprite()
    {
        if (quantity > 0)
        {
            _spriteRender.sprite = sprite[0];
        }
        if (quantity == 0)
        {
            _spriteRender.sprite = sprite[1];
        }
    }

    public void UpdateTextMeshPro()
    {
        textDisplay.text = null;
        textDisplay.text += quantity.ToString();
    }

    public void Subtract()
    {
        quantity--;
        if(quantity == 0)
        {
            cantMove = true;
        }
    }

    public void AddFood()
    {
        quantity++;
        if (quantity > 0)
        {
            cantMove = false;
        }
    }
}
