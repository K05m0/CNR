using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.PlayerLoop;
using FixedUpdate = UnityEngine.PlayerLoop.FixedUpdate;

namespace UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets
{
    public class HandStaminaProvider : MonoBehaviour
    {

        [SerializeField] private Rigidbody rb;
        [Header("Hands Stamina Settings")]
        public float staminaMaxValue;
        public float staminaCurrValue;
        public float drainingStaminaMultiplayer;
        [SerializeField] private float regenerateStaminaMultiplayer;
        [SerializeField] private float valueToRegenerateStamina;

        [Header("LayerMask")]
        [SerializeField] private InteractionLayerMask nothingMask;

        [SerializeField] private InteractionLayerMask baseMask;
        
        public XRDirectInteractor interactor;
        public DynamicMoveProvider provider;
        
        public bool isDrainingStamina;


        private Vector3 velocity;
        private Vector3 lastPos;

        public List<AudioClip> allObjectSound { get; set; }
        private void Awake()
        {
            staminaCurrValue = staminaMaxValue;
            lastPos = transform.position;


        }
        private void FixedUpdate()
        {
            CalculateVelocity();

            if (staminaCurrValue <= 0)
                interactor.interactionLayers = nothingMask;
            else if (staminaCurrValue >= staminaMaxValue)
                interactor.interactionLayers = baseMask;
                
            
            
            if (isDrainingStamina)
                staminaCurrValue -= Time.deltaTime * drainingStaminaMultiplayer;
            
            if(velocity.magnitude <= valueToRegenerateStamina)
                return;
            
            staminaCurrValue += regenerateStaminaMultiplayer;
            
            staminaCurrValue = Mathf.Clamp(staminaCurrValue, 0, staminaMaxValue);
            
        }

        private IEnumerator OnGravity()
        {
            StopAllCoroutines();
            yield return new WaitForSeconds(0.7f);
            provider.useGravity = false;
        }
        private void CalculateVelocity()
        {
            if(lastPos != transform.position) {
                velocity = transform.position - lastPos;
                velocity /= Time.deltaTime;
                lastPos = transform.position;
            }
        }

        public void StartDrainingStamina()
        {
            isDrainingStamina = true;
        }
        public void StomDrainingStamina()
        {
            isDrainingStamina = false;
        }
    }
}
