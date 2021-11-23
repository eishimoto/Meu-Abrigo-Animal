using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FoodToolTwo : MonoBehaviour
{
    private bool _moveAllowed;
    private Collider2D myCollider;
    private Vector2 _startPosition;

    private Camera maincamera;

    //private
    private SpriteRenderer _spriteRender;
    //collection
    [SerializeField] private List<Sprite> sprite = new List<Sprite>();
    //text
    [SerializeField] private TextMeshProUGUI textDisplay;
    [SerializeField] private int quantity;

    //sounds
    [Header("Tool SFX")] //E
    public AudioClip Bowl_Sound;
    AudioSource ToolSFXSource; //E

    //animation
    private Animator myAnimator;

    //bool
    public static bool cantMove;

    //static for function
    public static FoodToolTwo instance;
    private void OnEnable()
    {
        if (instance == null)
        {
            instance = this;
        }
        _startPosition = transform.position;
    }

    private void Start()
    {
        myCollider = GetComponent<Collider2D>();
        maincamera = Camera.main;

        ToolSFXSource = GetComponent<AudioSource>(); //E

        myAnimator = GetComponent<Animator>();
        _spriteRender = GetComponent<SpriteRenderer>();
        cantMove = false;
        UpdateTextMeshPro();
    }

    private void Update()
    {
        if (UICanvas.canUseTool == true)
        {
            if (cantMove == false)
            {
                MoveTool();
            }
        }
    }

    private void MoveTool()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

            if (touch.phase == TouchPhase.Began)
            {
                Collider2D touchedCollider = Physics2D.OverlapPoint(touchPosition);
                if (myCollider == touchedCollider)
                {
                    _moveAllowed = true;
                    myAnimator.SetBool("move", true);
                }
            }
            if (touch.phase == TouchPhase.Moved)
            {
                if (_moveAllowed)
                {
                    transform.position = new Vector2(touchPosition.x, touchPosition.y);
                }
            }

            if (touch.phase == TouchPhase.Ended)
            {
                if (touch.phase == TouchPhase.Ended)
                {
                    _moveAllowed = false;
                    transform.position = _startPosition;
                    myAnimator.SetBool("move", false);
                }
            }
        }
    }


    // Mouse as touch control
    private void OnMouseDrag()
    {
        if (UICanvas.canUseTool == true)
        {
            if (cantMove == false)
            {
                Vector3 mouseP = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z + 10f);
                Vector3 worldP = maincamera.ScreenToWorldPoint(mouseP);
                transform.position = worldP;
                myAnimator.SetBool("move", true);
            }
        }
    }

    private void OnMouseUp()
    {
        transform.position = _startPosition;
        myAnimator.SetBool("move", false);
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

        ToolSFXSource.PlayOneShot(Bowl_Sound, 2); //E

        if (quantity == 0)
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
        ChangeSprite();
    }
}
