using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MedicineTool : MonoBehaviour
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
    public AudioClip RedPill_N_MixPills_Sound;

    AudioSource ToolSFXSource; //E

    //bool
    public static bool cantMove;

    public static MedicineTool instance;
    private void OnEnable()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        myCollider = GetComponent<Collider2D>();
        _startPosition = transform.position;
        maincamera = Camera.main;

        ToolSFXSource = GetComponent<AudioSource>(); //E

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
            }
        }
    }

    private void OnMouseUp()
    {
        transform.position = _startPosition;
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

        ToolSFXSource.PlayOneShot(RedPill_N_MixPills_Sound); //E

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
    }

    public void PlayMedecineSound()
    {
        ToolSFXSource.PlayOneShot(RedPill_N_MixPills_Sound);
    }
}
