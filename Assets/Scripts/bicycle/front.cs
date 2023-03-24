using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class front : MonoBehaviour
{   
    // on FrontWheel.028
    private float speed = 20.0f;
    private float turnSpeed = 30.0f;
    private float leftAngle = -45.0f;
    private float rightAngle = 45.0f;

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
        if (Input.GetKey("left")) {
            var y = UnityEditor.TransformUtils.GetInspectorRotation(gameObject.transform).y;
            if (y > leftAngle) {
                transform.Rotate(new Vector3(0, -turnSpeed*Time.deltaTime, 0), Space.World);
            }
        }
        if (Input.GetKey("right")) {
            var y = UnityEditor.TransformUtils.GetInspectorRotation(gameObject.transform).y;
            if (y < rightAngle) {
                transform.Rotate(new Vector3(0, turnSpeed*Time.deltaTime, 0), Space.World);
            }

        }

    }
}
