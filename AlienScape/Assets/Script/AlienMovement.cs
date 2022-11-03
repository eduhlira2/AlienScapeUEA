using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienMovement : MonoBehaviour
{
    public GameObject alien;
    public Rigidbody2D rbAlien;
    Quaternion targetAngle_0 = Quaternion.Euler(0,0,0);
    Quaternion targetAngle_90 = Quaternion.Euler(0,0,360);
    public Quaternion currentAngle;
    
    
    // Start is called before the first frame update
    void Start()
    {
        rbAlien = rbAlien.GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
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
}
