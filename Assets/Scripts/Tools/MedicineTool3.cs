using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MedicineTool3 : MonoBehaviour
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
    //animation
    private Animator myAnimator;

    //sounds
    [Header("Tool SFX")] //E
    public AudioClip BluePill_Sound;
    AudioSource ToolSFXSource; //E

    //bool
    public static bool cantMove;

    public static MedicineTool3 instance;
    private void OnEnable()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        myAnimator = GetComponent<Animator>();
        myCollider = GetComponent<Collider2D>();
        _startPosition = transform.position;
        maincamera = Camera.main;

        ToolSFXSource = GetComponent<AudioSource>(); //E

        _spriteRender = GetComponent<SpriteRenderer>();
        UpdateTextMeshPro();
        ChangeSprite();
        cantMove = true;
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
                    myAnimator.SetBool("blue", true);
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
                    myAnimator.SetBool("blue", false);
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
                myAnimator.SetBool("blue", true);
            }
        }
    }

    private void OnMouseUp()
    {
        transform.position = _startPosition;
        myAnimator.SetBool("blue", false);
    }
    public void UseInStats()
    {
        Subtract();
        UpdateTextMeshPro();
        ChangeSprite();
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

        ToolSFXSource.PlayOneShot(BluePill_Sound); //E

        if (quantity == 0)
        {
            cantMove = true;
        }
    }

    public void AddMedicine()
    {
        quantity++;
        if (quantity > 0)
        {
            cantMove = false;
        }
        ChangeSprite();
        UpdateTextMeshPro();
    }
}
