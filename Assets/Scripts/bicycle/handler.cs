using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handler : MonoBehaviour
{
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
        if (Input.GetKey("left")) {
            var y = UnityEditor.TransformUtils.GetInspectorRotation(gameObject.transform).y;
            if (y > leftAngle) {
                transform.Rotate(new Vector3( 0, -turnSpeed*Time.deltaTime, 0 ), Space.World);
            }
        }
        if (Input.GetKey("right")) {
            var y = UnityEditor.TransformUtils.GetInspectorRotation(gameObject.transform).y;
            if (y < rightAngle) {
                transform.Rotate(new Vector3( 0, turnSpeed*Time.deltaTime, 0 ), Space.World);
            }
        }
    }
}
