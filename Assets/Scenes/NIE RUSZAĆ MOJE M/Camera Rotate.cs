using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    public Transform target;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       

        
        
            transform.LookAt(target);
            transform.Translate(Vector3.right * (Time.deltaTime * speed));
        

    }
}
