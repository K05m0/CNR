using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandController : MonoBehaviour
{
    public GameObject Tempolary;
    public GameObject HoldingObject;
    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("ClimbAble"))
        {
            Tempolary = other.gameObject;
        }
    }

    public void Interact()
    {
        if(Tempolary != null)
        {
            HoldingObject = Tempolary;
            Debug.Log(gameObject.name + " Holding: " + HoldingObject.name);
        }

    }

    public void StopInterct()
    {
        Tempolary = null;
        HoldingObject = null;
    }
}
