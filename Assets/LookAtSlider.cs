using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtSlider : MonoBehaviour
{
    private GameObject camera;
    void Start()
    {
        camera = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(camera.transform);
    }
}
