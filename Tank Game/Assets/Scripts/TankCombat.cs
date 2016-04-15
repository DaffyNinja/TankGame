using UnityEngine;
using System.Collections;

public class TankCombat : MonoBehaviour
{

    public float missleSpeed;
    public GameObject missleObj;
    public Transform missileShotPos;


    GameObject miss;


    // Use this for initialization
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {

        //if (Input.GetKeyDown(KeyCode.RightControl))
        //{
        //    miss = Instantiate(missleObj, missileShotPos.position, Quaternion.Euler(90f,0,0)) as GameObject;

        //    Vector3 vForce = transform.forward * missleSpeed + transform.forward;
        //    miss.GetComponent<Rigidbody>().AddForce(vForce, ForceMode.Impulse);
        //}


    }
}
