using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoreStaminaUsePoint : MonoBehaviour
{
    private SphereCollider collider;
    public float staminaDrainMultiplayer;
    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<SphereCollider>();
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, collider.radius);
    }
}
