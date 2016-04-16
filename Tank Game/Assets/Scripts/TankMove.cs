using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TankMove : MonoBehaviour
{

    public float topSpeed;
    public float accelarateSpeed;
    public float turnSpeed;

    public float gravityNum;

    private float powerInput;
    private float turnInput;

    public bool turn;

    private Rigidbody carRigidbody;

    float moveSpeed;

    public bool canMoveTurret;

    [Space(5)]
    public float hoverForce;
    public float hoverHeight;

    [Space(5)]
    public Text speedText;


    void Awake()
    {
        carRigidbody = GetComponent<Rigidbody>();


    }

    void Update()
    {
     

        //Hover
        Ray ray = new Ray(transform.position, -transform.up);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, hoverHeight))
        {
            // print("Hit");

            float proportionalHeight = (hoverHeight - hit.distance) / hoverHeight;
            Vector3 appliedHoverForce = Vector3.up * proportionalHeight * hoverForce;
            carRigidbody.AddForce(appliedHoverForce, ForceMode.Acceleration);
        }

        powerInput = Input.GetAxis("Vertical");
        turnInput = Input.GetAxis("Horizontal");

        if (moveSpeed <= topSpeed)
        {
            if (Input.GetAxis("Vertical") >= 0.05f)
            {
                // print("Move");
                moveSpeed += accelarateSpeed * Time.deltaTime;
                carRigidbody.AddRelativeForce(0f, 0f, powerInput * moveSpeed);
            }
            else if (Input.GetAxis("Vertical") < 0)
            {
                //print("BacK");

                moveSpeed += accelarateSpeed * Time.deltaTime;
                carRigidbody.AddRelativeForce(0f, 0f, -powerInput * -moveSpeed);
            }

        }
        else if (Input.GetAxis("Vertical") >= 0.05f)
        {
            carRigidbody.AddRelativeForce(0f, 0f, powerInput * moveSpeed);
        }
        else
        {
            carRigidbody.AddRelativeForce(0f, 0f, -powerInput * -moveSpeed);
        }
      
        
           

        if (Input.GetAxis("Vertical") == 0)
        {
            // print("Off");
            moveSpeed = 0;
        }


        if (moveSpeed == 0)
        {
            canMoveTurret = true;
            turn = false;
        }
        else
        {
            turn = true;
            canMoveTurret = false;
        }

        if (turn)
        {
            carRigidbody.AddRelativeTorque(0f, turnInput * turnSpeed, 0f);
        }


        speedText.text = moveSpeed.ToString();

        //print(moveSpeed.ToString());

    }


}
