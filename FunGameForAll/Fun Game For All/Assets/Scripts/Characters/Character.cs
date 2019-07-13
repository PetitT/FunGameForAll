using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public abstract class Character : MonoBehaviour
{
    #region variables

    private Rigidbody2D rb;
    private float moveSpeed;
    private float jumpForce;
    private float moveInputs;

    private bool isGrounded = true;
    private bool canMove = true;

    private float jumpTimeCounter;
    private float jumpTime;
    private bool isJumping;

    private int maxHealth;
    private int currentHealth;

    private Color victoryColor;
    private string victoryText;

    [SerializeField] private int playerNumber;

    protected int characterIndex;

    public int MaxHealth { get => maxHealth; set => maxHealth = value; }
    public int CurrentHealth { get => currentHealth; set { NumberChanged(currentHealth - value); currentHealth = value; } }
    public int PlayerNumber { get => playerNumber; set => playerNumber = value; }
    public bool CanMove { get => canMove; set => canMove = value; }
    public Color VictoryColor { get => victoryColor; set => victoryColor = value; }
    public string VictoryText { get => victoryText; set => victoryText = value; }
    public float MoveSpeed { get => moveSpeed; set => moveSpeed = value; }

    #endregion

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        MoveSpeed = FindObjectOfType<DataContainer>().data.characters[characterIndex].moveSpeed;
        jumpForce = FindObjectOfType<DataContainer>().data.characters[characterIndex].jumpForce;
        jumpTime = FindObjectOfType<DataContainer>().data.characters[characterIndex].jumpTime;
        MaxHealth = FindObjectOfType<DataContainer>().data.characters[characterIndex].maxHealth;
        VictoryColor = FindObjectOfType<DataContainer>().data.characters[characterIndex].color;
        VictoryText = FindObjectOfType<DataContainer>().data.characters[characterIndex].victoryText;
        CurrentHealth = MaxHealth;
    }

    private void FixedUpdate()
    {
        if (PlayerNumber == 1)
            moveInputs = Input.GetAxis("Horizontal");

        if (PlayerNumber == 2)
        {
            if (Input.GetKey(KeyCode.Q))
                moveInputs = -1;
            else if (Input.GetKey(KeyCode.D))
                moveInputs = 1;
            else
                moveInputs = 0;
        }

        if (CanMove)
            rb.velocity = new Vector2(moveInputs * MoveSpeed, rb.velocity.y);
    }

    public virtual void Update()
    {
        #region Inputs

        if (CanMove)
        {

            if (moveInputs > 0)
                transform.eulerAngles = new Vector3(0, 0, 0);
            else if (moveInputs < 0)
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
            }

            if (isGrounded)
                if (PlayerNumber == 1 && Input.GetKeyDown(KeyCode.Joystick1Button0) || PlayerNumber == 2 && Input.GetKeyDown(KeyCode.Space))
                {
                    isGrounded = false;
                    isJumping = true;
                    jumpTimeCounter = jumpTime;
                    rb.velocity = Vector2.up * jumpForce;
                }

            if (isJumping)
                if (PlayerNumber == 1 && Input.GetKey(KeyCode.Joystick1Button0) || PlayerNumber == 2 && Input.GetKey(KeyCode.Space))
                {
                    if (jumpTimeCounter > 0)
                    {
                        rb.velocity = Vector2.up * jumpForce;
                        jumpTimeCounter -= Time.deltaTime;
                    }
                    else
                    {
                        isJumping = false;
                    }
                }

            if (PlayerNumber == 1 && Input.GetKeyUp(KeyCode.Joystick1Button0) || PlayerNumber == 2 && Input.GetKeyUp(KeyCode.Space))
            {
                isJumping = false;
            }


            if (PlayerNumber == 1 && Input.GetKeyDown(KeyCode.Joystick1Button1) || PlayerNumber == 2 && Input.GetKeyDown(KeyCode.J))
                Special1();

            if (PlayerNumber == 1 && Input.GetKeyDown(KeyCode.Joystick1Button2) || PlayerNumber == 2 && Input.GetKeyDown(KeyCode.K))
                Special2();

            if (PlayerNumber == 1 && Input.GetKeyDown(KeyCode.Joystick1Button3) || PlayerNumber == 2 && Input.GetKeyDown(KeyCode.L))
                Special3();
            
        }
        #endregion

        #region checks

        #endregion
    }

    #region methods

    public virtual void Special1()
    {

    }

    public virtual void Special2()
    {

    }

    public virtual void Special3()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    public virtual void NumberChanged(int value)
    {
        if (currentHealth >= MaxHealth)
            currentHealth = MaxHealth;

        if (currentHealth <= 0)
            Death();

    }

    public IEnumerator Assommer(float stunTime)
    {
        canMove = false;
        yield return new WaitForSeconds(stunTime);
        canMove = true;
    }


    public void Death()
    {
        
    }

    #endregion


}
