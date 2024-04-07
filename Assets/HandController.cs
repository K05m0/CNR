using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;

public class HandController : MonoBehaviour
{
    public GameObject Tempolary;
    public GameObject HoldingObject;
    public HandStaminaProvider HandStaminaProvider;
    public AudioSource HandAudioSource;

    private bool isAdd;
    private float tempVal;

    private void Awake()
    {
        HandStaminaProvider = GetComponent<HandStaminaProvider>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("ClimbAble"))
        {
            Tempolary = other.gameObject;
        }
    }
    public void OnCollisionExit(Collision collision)
    {
        if (Tempolary == null && isAdd)
            return;

        HandStaminaProvider.drainingStaminaMultiplayer -= tempVal;
        isAdd = false;
        tempVal = 0;
    }


    public void Interact()
    {
        if (Tempolary == null)
            return;

            HoldingObject = Tempolary;
            Debug.Log(gameObject.name + " Holding: " + HoldingObject.name);

        if (Tempolary.TryGetComponent<MoreStaminaUsePoint>(out MoreStaminaUsePoint moreStaminaUse))
        {
            HandStaminaProvider.drainingStaminaMultiplayer += moreStaminaUse.staminaDrainMultiplayer;
            isAdd = true;
            tempVal = moreStaminaUse.staminaDrainMultiplayer;
        }

        if (HoldingObject.TryGetComponent<FallingPoint>(out FallingPoint point))
            point.StartCunting();

        IPoint audioPoint = HoldingObject.GetComponent<IPoint>();
        int randomNum = Random.Range(0, audioPoint.allObjectSound.Count);

        AudioClip clipToPlay = audioPoint.allObjectSound[randomNum];
        HandAudioSource.clip = clipToPlay;
        HandAudioSource.Play();
    }

    public void StopInterct()
    {
        Tempolary = null;
        HoldingObject = null;
    }
}
