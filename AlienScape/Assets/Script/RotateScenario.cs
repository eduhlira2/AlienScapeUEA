using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public class RotateScenario : MonoBehaviour
{
    public GameObject scenario;
    Quaternion targetAngle_0 = Quaternion.Euler(0,0,0);
    Quaternion targetAngle_90 = Quaternion.Euler(0,0,90);
    Quaternion targetAngle_180 = Quaternion.Euler(0,0,180);
    Quaternion targetAngle_270 = Quaternion.Euler(0,0,270);
    Quaternion targetAngle_360 = Quaternion.Euler(0,0,360);
    public Quaternion currentAngle;
    
    // Start is called before the first frame update
    void Start()
    {
        currentAngle = targetAngle_0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            ChangeAngleLeft();
            
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            ChangeAngleRight();
            
        }
        scenario.transform.rotation = Quaternion.Slerp(scenario.transform.rotation, currentAngle, 0.02f);
    }

    void ChangeAngleLeft()
    {
        if (currentAngle.eulerAngles.z == targetAngle_360.eulerAngles.z)
        {
            currentAngle = targetAngle_0;
        }
        if (currentAngle.eulerAngles.z == targetAngle_270.eulerAngles.z)
        {
            currentAngle = targetAngle_360;
        }
        if (currentAngle.eulerAngles.z == targetAngle_180.eulerAngles.z)
        {
            currentAngle = targetAngle_270;
        }
        if (currentAngle.eulerAngles.z == targetAngle_90.eulerAngles.z)
        {
            currentAngle = targetAngle_180;
        }
        if (currentAngle.eulerAngles.z == targetAngle_0.eulerAngles.z)
        {
            currentAngle = targetAngle_90;
        }
    }

    void ChangeAngleRight()
    {
        if (currentAngle.eulerAngles.z == targetAngle_0.eulerAngles.z)
        {
            currentAngle = targetAngle_360;
        }
        if (currentAngle.eulerAngles.z == targetAngle_90.eulerAngles.z)
        {
            currentAngle = targetAngle_0;
        }
        if (currentAngle.eulerAngles.z == targetAngle_180.eulerAngles.z)
        {
            currentAngle = targetAngle_90;
        }
        if (currentAngle.eulerAngles.z == targetAngle_270.eulerAngles.z)
        {
            currentAngle = targetAngle_180;
        }
        if (currentAngle.eulerAngles.z == targetAngle_360.eulerAngles.z)
        {
            currentAngle = targetAngle_270;
        }
       
    }
}
