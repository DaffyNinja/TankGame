using UnityEngine;
using System.Collections;

public class TurretMove : MonoBehaviour
{

    public bool useTurret;
    [Space(5)]
    public float rotateSpeed;

    Transform pivot;

    float turnInput;

    // Rigidbody rig;

    //Combat
    [Space(10)]
    public float missleSpeed;
    public GameObject missleObj;
    public Transform missileShotPos;

    Vector3 fwd;
    GameObject miss;

    TankMove tMove;

    // Use this for initialization
    void Start()
    {
        //rig = GetComponent<Rigidbody>();

        pivot = transform.FindChild("New Pivot");

        tMove = GetComponentInParent<TankMove>();

    }

    // Update is called once per frame
    void Update()
    {
        if (tMove.canMoveTurret)
        {

            fwd = transform.TransformDirection(Vector3.forward);

            turnInput = Input.GetAxis("Horizontal");

            transform.RotateAround(pivot.position, Vector3.up, turnInput * rotateSpeed);

            // transform.Rotate(0, turnInput * rotateSpeed, 0);
            // rig.AddRelativeTorque(0, turnInput * rotateSpeed, 0);
        }

        if (Input.GetKeyDown(KeyCode.RightControl))
        {
            miss = Instantiate(missleObj, missileShotPos.position, Quaternion.Euler(90, 0, 0)) as GameObject;

            // Vector3 vForce = transform.forward * missleSpeed + transform.forward;
            miss.GetComponent<Rigidbody>().AddForce(fwd * missleSpeed, ForceMode.Impulse);
        }


    }
}
