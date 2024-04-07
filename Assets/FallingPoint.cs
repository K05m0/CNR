using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class FallingPoint : IPoint
{
    private Rigidbody rb;

    [SerializeField] private float timeToFall;
    [SerializeField] private float timeToDestroy;

    [SerializeField] private bool debug;

    public List<AudioClip> allObjectSound { get; set; }

    [Header("LayerMask")]
    [SerializeField] private InteractionLayerMask nothingMask;

    [SerializeField] private InteractionLayerMask baseMask;

    
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
        rb.useGravity = false;
    }

    private void Update()
    {
        if (debug)
            StartCunting(null);
    }

    public void StartCunting(XRDirectInteractor interactor)
    {
        Debug.Log("chuj");
        StartCoroutine(Falling(interactor));
    }

    private IEnumerator Falling(XRDirectInteractor interactor)
    {
        yield return new WaitForSeconds(timeToFall);
        rb.isKinematic = false;
        rb.useGravity = true;
        interactor.interactionLayers = nothingMask;
        Debug.Log(interactor.gameObject.name + " " +  interactor.interactionLayerMask.value.ToString());
        yield return new WaitForSeconds(timeToDestroy);
        Debug.Log(interactor.gameObject.name + " " +  interactor.interactionLayerMask.value.ToString());
        interactor.interactionLayers = baseMask;
        Destroy(gameObject);
    }
}
