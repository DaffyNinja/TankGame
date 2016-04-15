using UnityEngine;
using System.Collections;

public class Missle : MonoBehaviour {

    public float destroyTime;
    float timer;

    bool created;
    bool destroy;

	// Use this for initialization
	void Start ()
    {
        created = true;

	
	}
	
	// Update is called once per frame
	void Update ()
    {

        if (created)
        {
            timer += Time.deltaTime;

            if (timer >= destroyTime)
            {
                timer = 0;
                created = false;
                Destroy(this.gameObject);
            }
        }

    

    }
}
