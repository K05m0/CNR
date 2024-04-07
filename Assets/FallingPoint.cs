using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FallingPoint : MonoBehaviour, IPoint
{
    private Rigidbody rb;

    [SerializeField] private float timeToFall;

    [SerializeField] private bool debug;

    public List<AudioClip> allObjectSound { get; set; }

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
        rb.useGravity = false;
    }

    private void Update()
    {
        if (debug)
            StartCunting();
    }

    public void StartCunting()
    {
        StartCoroutine(Falling());
    }

    private IEnumerator Falling()
    {
        yield return new WaitForSeconds(timeToFall);
        rb.isKinematic = false;
        rb.useGravity = true;
        yield return new WaitForSeconds(timeToFall);
        Destroy(gameObject);
    }
}
