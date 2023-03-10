using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleaningTool : MonoBehaviour
{
    //movement
    private bool _moveAllowed;
    private Collider2D myCollider;
    private Vector2 _startPosition;
    private Camera maincamera;

    //drawing variables
    [SerializeField] private List<GameObject> areaToDraw;
    private bool square1, square2, square3, square4;
    private bool circle1, circle2, circle3, circle4;
    private bool triangle1, triangle2, triangle3;
    private int randomForm;
    public static bool squareClean, circleClean, triangleClean;
    [SerializeField] private List<GameObject> trianglePoints;
    [SerializeField] private List<GameObject> CirclesPoitns;
    [SerializeField] private List<GameObject> SquarePoins;

    //particles
    [SerializeField] List<GameObject> particles;
    private bool bubbles;

    public bool soap, shampoo;

    //sounds
    [Header("Tool SFX")] //E
    public AudioClip Soap_Shampoo_Sound;
    AudioSource ToolSFXSource; //E. Adicionei um AudioSource aos assets de ferramentas

    //Animation
    private Animator myAnimator;

    //sound enabler
    [Header("Enable SFX")] //E
    private bool SFX1, SFX2, SFX3, SFX4;

    public static bool firtstToolUsed;
    public static bool soapOn = false, shampooOn = false;

    public static CleaningTool instance;
    public void OnEnable()
    {
        if (instance == null)
        {
            instance = this;
        }
        bubbles = true;
    }
    public void OnDisable()
    {
        bubbles = false;
        DisableBubbles();
    }
    private void Start()
    {
        myAnimator = GetComponent<Animator>();
        myCollider = GetComponent<Collider2D>();
        ToolSFXSource = GetComponent<AudioSource>(); //E
        SFX1 = true; SFX2 = true; SFX3 = true; SFX4 = true; //E
        _startPosition = transform.position;
        maincamera = Camera.main;
        randomForm = Random.Range(0, 3);

        if (soap)
        {
            soapOn = true;
        }
        if (shampoo)
        {
            shampooOn = true;
            soapOn = false;
        }
    }

    private void Update()
    {
        if (UICanvas.canUseTool == true)
        {
            MoveTool();
        }
        CheckCollisions();
        ActivateFromsPoints();
        ActiveBubbleParticles();
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
                    areaToDraw[randomForm].SetActive(true);
                    AnimationCheck();


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
                    areaToDraw[randomForm].SetActive(false);
                    SetAllToFalse();
                    randomForm = Random.Range(0, 3);
                    StopAnimationCheck();
                }
            }
        }
    }


    // Mouse as touch control
    private void OnMouseDrag()
    {
        if (UICanvas.canUseTool == true)
        {
            Vector3 mouseP = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z + 10f);
            Vector3 worldP = maincamera.ScreenToWorldPoint(mouseP);
            transform.position = worldP;
            areaToDraw[randomForm].SetActive(true);
            AnimationCheck();
        }
    }

    private void OnMouseUp()
    {
        areaToDraw[randomForm].SetActive(false);
        transform.position = _startPosition;
        SetAllToFalse();
        ResetSFXBools(); //E
        randomForm = Random.Range(0, 3);
        StopAnimationCheck();
    }
    private void AnimationCheck()
    {
        if (soapOn)
        {
            myAnimator.SetBool("soap", true);
        }
        if (shampooOn)
        {
            myAnimator.SetBool("shampoo", true);
        }
    }

    private void StopAnimationCheck()
    {
        if (soapOn)
        {
            myAnimator.SetBool("soap", false);
        }
        if (shampooOn)
        {
            myAnimator.SetBool("shampoo", false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Square1"))
        {
            square1 = true;

            if (soapOn || shampooOn) //E
            {
                if (SFX1 && square1)
                {
                    ToolSFXSource.PlayOneShot(Soap_Shampoo_Sound);
                    SFX1 = false;
                }
            }
        }
        if (collision.CompareTag("Square2"))
        {
            square2 = true;

            if (soapOn || shampooOn) //E
            {
                if (SFX2 && square2)
                {
                    ToolSFXSource.PlayOneShot(Soap_Shampoo_Sound);
                    SFX2 = false;
                }
            }
        }
        if (collision.CompareTag("Square3"))
        {
            square3 = true;

            if (soapOn || shampooOn) //E
            {
                if (SFX3 && square3)
                {
                    ToolSFXSource.PlayOneShot(Soap_Shampoo_Sound);
                    SFX3 = false;
                }
            }
        }
        if (collision.CompareTag("Square4"))
        {
            square4 = true;

            if (soapOn || shampooOn) //E
            {
                if (SFX4 && square4)
                {
                    ToolSFXSource.PlayOneShot(Soap_Shampoo_Sound);
                    SFX4 = false;
                }
            }
        }

        if (collision.CompareTag("Circle1"))
        {
            circle1 = true;

            if (soapOn || shampooOn) //E
            {
                if (SFX1 && circle1)
                {
                    ToolSFXSource.PlayOneShot(Soap_Shampoo_Sound);
                    SFX1 = false;
                }
            }
        }
        if (collision.CompareTag("Circle2"))
        {
            circle2 = true;

            if (soapOn || shampooOn) //E
            {
                if (SFX2 && circle2)
                {
                    ToolSFXSource.PlayOneShot(Soap_Shampoo_Sound);
                    SFX2 = false;
                }
            }
        }
        if (collision.CompareTag("Circle3"))
        {
            circle3 = true;

            if (soapOn || shampooOn) //E
            {
                if (SFX3 && circle3)
                {
                    ToolSFXSource.PlayOneShot(Soap_Shampoo_Sound);
                    SFX3 = false;
                }
            }
        }
        if (collision.CompareTag("Circle4"))
        {
            circle4 = true;

            if (soapOn || shampooOn) //E
            {
                if (SFX1 && circle4)
                {
                    ToolSFXSource.PlayOneShot(Soap_Shampoo_Sound);
                    SFX4 = false;
                }
            }
        }

        if (collision.CompareTag("Triangle1"))
        {
            triangle1 = true;

            if (soapOn || shampooOn) //E
            {
                if (SFX1 && triangle1)
                {
                    ToolSFXSource.PlayOneShot(Soap_Shampoo_Sound);
                    SFX1 = false;
                }
            }
        }
        if (collision.CompareTag("Triangle2"))
        {
            triangle2 = true;

            if (soapOn || shampooOn) //E
            {
                if (SFX2 && triangle3)
                {
                    ToolSFXSource.PlayOneShot(Soap_Shampoo_Sound);
                    SFX2 = false;
                }
            }
        }
        if (collision.CompareTag("Triangle3"))
        {
            triangle3 = true;

            if (soapOn || shampooOn) //E
            {
                if (SFX3 && triangle3)
                {
                    ToolSFXSource.PlayOneShot(Soap_Shampoo_Sound);
                    SFX3 = false;
                }
            }
        }
    }

    private void ActiveBubbleParticles()
    {
        if(firtstToolUsed && bubbles)
        {
            if(UICanvas.on)
            {
                particles[0].SetActive(true);
            }
            if (UICanvas.on2)
            {
                particles[1].SetActive(true);
            }
            if (UICanvas.on3)
            {
                particles[2].SetActive(true);
            }
            if (UICanvas.on4)
            {
                particles[3].SetActive(true);
            }

        }
        else if(!firtstToolUsed)
        {
            if (UICanvas.on)
            {
                particles[0].SetActive(false);
            }
            if (UICanvas.on2)
            {
                particles[1].SetActive(false);
            }
            if (UICanvas.on3)
            {
                particles[2].SetActive(false);
            }
            if (UICanvas.on4)
            {
                particles[3].SetActive(false);
            }
        }
    }

    public void DisableBubbles()
    {
        firtstToolUsed = false;
        for (int i = 0; i < particles.Count; i++)
        {
            particles[i].SetActive(false);
        }
    }
    private void CheckCollisions()
    {
        if(square1 == true && square2 == true && square3 == true && square4 == true)
        {
            squareClean = true;
            firtstToolUsed = true;
        }

        if(circle1 == true && circle2 == true && circle3 == true && circle4 == true)
        {
            circleClean = true;
            firtstToolUsed = true;
        }

        if (triangle1 == true && triangle2 == true && triangle3 == true)
        {
            triangleClean = true;
            firtstToolUsed = true;
        }
    }

    private void SetAllToFalse()
    {
        square1 = false;
        square2 = false;
        square3 = false;
        square4 = false;

        circle1 = false;
        circle2 = false;
        circle3 = false;
        circle4 = false;

        triangle1 = false;
        triangle2 = false;
        triangle3 = false;
    }

    private void ResetSFXBools() //E
    {
        SFX1 = true;
        SFX2 = true;
        SFX3 = true;
        SFX4 = true;
    }

    private void ActivateFromsPoints()
    {
        if(triangle1)
        {
            trianglePoints[0].SetActive(true);
        }
        else if(triangle1 == false)
        {
            trianglePoints[0].SetActive(false);
        }
        if (triangle2)
        {
            trianglePoints[1].SetActive(true);
        }
        else if (triangle2 == false)
        {
            trianglePoints[1].SetActive(false);
        }
        if (triangle3)
        {
            trianglePoints[2].SetActive(true);
        }
        else if (triangle3 == false)
        {
            trianglePoints[2].SetActive(false);
        }

        if(circle1)
        {
            CirclesPoitns[0].SetActive(true);
        }
        else if(circle1 == false)
        {
            CirclesPoitns[0].SetActive(false);
        }
        if (circle2)
        {
            CirclesPoitns[1].SetActive(true);
        }
        else if (circle2 == false)
        {
            CirclesPoitns[1].SetActive(false);
        }
        if (circle3)
        {
            CirclesPoitns[2].SetActive(true);
        }
        else if (circle3 == false)
        {
            CirclesPoitns[2].SetActive(false);
        }
        if (circle4)
        {
            CirclesPoitns[3].SetActive(true);
        }
        else if (circle4 == false)
        {
            CirclesPoitns[3].SetActive(false);
        }

        if(square1)
        {
            SquarePoins[0].SetActive(true);
        }
        else if(square1 == false)
        {
            SquarePoins[0].SetActive(false);
        }

        if (square2)
        {
            SquarePoins[1].SetActive(true);
        }
        else if (square2 == false)
        {
            SquarePoins[1].SetActive(false);
        }

        if (square3)
        {
            SquarePoins[2].SetActive(true);
        }
        else if (square3 == false)
        {
            SquarePoins[2].SetActive(false);
        }

        if (square4)
        {
            SquarePoins[3].SetActive(true);
        }
        else if (square4 == false)
        {
            SquarePoins[3].SetActive(false);
        }
    }
}
