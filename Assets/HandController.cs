using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;

public class HandController : MonoBehaviour
{
    public GameObject Tempolary;
    public GameObject HoldingObject;
    public HandStaminaProvider HandStaminaProvider;
    public XRDirectInteractor interactor;
    public AudioSource HandAudioSource;

    private bool isAdd;
    private float tempVal;

    private void Awake()
    {
        HandStaminaProvider = GetComponent<HandStaminaProvider>();
        HandAudioSource = GetComponent<AudioSource>();
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
        if(collision.gameObject.TryGetComponent<MoreStaminaUsePoint>(out MoreStaminaUsePoint stamina))
        HandStaminaProvider.drainingStaminaMultiplayer -= tempVal;
        isAdd = false;
        Tempolary = null;
        tempVal = 0;
        
    }


    public void Interact()
    {
        if (Tempolary == null)
            return;

            HoldingObject = Tempolary;

        if (Tempolary.TryGetComponent<MoreStaminaUsePoint>(out MoreStaminaUsePoint moreStaminaUse))
        {
            HandStaminaProvider.drainingStaminaMultiplayer += moreStaminaUse.staminaDrainMultiplayer;
            isAdd = true;
            tempVal = moreStaminaUse.staminaDrainMultiplayer;
        }

        if (HoldingObject.TryGetComponent<FallingPoint>(out FallingPoint point))
            point.StartCunting(interactor);

        
        IPoint audioPoint = HoldingObject.GetComponent<IPoint>();
        if(audioPoint == null || audioPoint.allObjectSound == null)
            return;
        
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
