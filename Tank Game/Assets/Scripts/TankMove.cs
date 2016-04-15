using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TankMove : MonoBehaviour
{

    public float topSpeed;
    public float accelarateSpeed;
    public float turnSpeed;

    private float powerInput;
    private float turnInput;

    public bool turn;

    private Rigidbody carRigidbody;

    float moveSpeed;

    [Space(5)]
    public Text speedText;


    void Awake()
    {
        carRigidbody = GetComponent<Rigidbody>();


    }

    void Update()
    {
        powerInput = Input.GetAxis("Vertical");
        turnInput = Input.GetAxis("Horizontal");

        if (moveSpeed <= topSpeed)
        {
            if (Input.GetAxis("Vertical") >= 0.05f)
            {
                // print("Move");
                moveSpeed += accelarateSpeed * Time.deltaTime;
            }
            
        }

        if (Input.GetAxis("Vertical") == 0)
        {
           // print("Off");
            moveSpeed = 0;
        }


        carRigidbody.AddRelativeForce(0f, 0f, powerInput * moveSpeed);
        if (turn)
        {
            carRigidbody.AddRelativeTorque(0f, turnInput * turnSpeed, 0f);
        }

        speedText.text = moveSpeed.ToString();

        //print(moveSpeed.ToString());

    }


}
