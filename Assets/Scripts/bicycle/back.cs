using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class back : MonoBehaviour
{
    // on BackWheel.029
    private float speed = 20.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("up")) { 
            transform.Rotate(0, 0, speed*Time.deltaTime); 
        }
        if (Input.GetKey("down")) { 
            transform.Rotate(0, 0, -speed*Time.deltaTime); 
        }
    }
}
