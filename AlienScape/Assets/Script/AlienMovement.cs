using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AlienMovement : MonoBehaviour
{
    public GameObject alien;
    public Rigidbody2D rbAlien;
    Quaternion targetAngle_0 = Quaternion.Euler(0,0,0);
    Quaternion targetAngle_90 = Quaternion.Euler(0,0,360);
    public Quaternion currentAngle;
    private float moveInput;
    public float moveSpeed;
    public GameObject coin;
    public Sprite doorSprite;
    public GameObject door;
    private SpriteRenderer doorSR;
    public string nextStage;
    public string actualScene;
    
    private bool openDoor = false;
    
    // Start is called before the first frame update
    void Start()
    {
        doorSR = door.GetComponent<SpriteRenderer>();
        rbAlien = rbAlien.GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        rbAlien.velocity = new Vector2(moveInput * moveSpeed, rbAlien.velocity.y);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            ChangeAlienAngleLeft();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            ChangeAlienAngleRight();
            
        }
        alien.transform.rotation = Quaternion.Slerp(alien.transform.rotation, currentAngle, 0.02f);
    }

    void ChangeAlienAngleRight()
    {
       currentAngle = targetAngle_0;

    }

    void ChangeAlienAngleLeft()
    {
            currentAngle = targetAngle_90;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "coin")
        {
         coin.SetActive(false);
         Debug.Log("Pegou a moeda!");
         doorSR.sprite = doorSprite;
         Debug.Log("Abriu a Porta!");
         openDoor = true;
        }
        
        if (col.gameObject.tag == "Door" && openDoor ==  true)
        {
           Debug.Log("Entrou na Porta");
           SceneManager.LoadScene(nextStage);
        }
        if (col.gameObject.tag == "Spike")
        {
            SceneManager.LoadScene(actualScene);
        }
    }
}
