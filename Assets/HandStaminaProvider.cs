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
        [Header("Hands Stamina Settings")]
        public float staminaMaxValue;
        public float staminaCurrValue;
        [SerializeField] private float drainingStaminaMultiplayer;
        [SerializeField] private float regenerateStaminaMultiplayer;
        [SerializeField] private float valueToRegenerateStamina;

        [Header("LayerMask")]
        [SerializeField] private InteractionLayerMask baseMask;
        [SerializeField] private InteractionLayerMask nothingMask;

        
        public XRDirectInteractor interactor;
        public bool isDrainingStamina;
        
        //private Vector3 handShake;
        private int handShake;

        private Vector3 velocity;
        private Vector3 lastPos; 
        
        private void Awake()
        {
            staminaCurrValue = staminaMaxValue;
            lastPos = transform.position;

        }
        private void FixedUpdate()
        {
            CalculateVelocity();
            Debug.Log(velocity.magnitude);
            
            
            if (staminaCurrValue <= 0)
                interactor.interactionLayers = nothingMask;
            
            if (isDrainingStamina)
                staminaCurrValue -= Time.deltaTime * drainingStaminaMultiplayer;
            
            if(velocity.magnitude <= valueToRegenerateStamina)
                return;
            
            staminaCurrValue += regenerateStaminaMultiplayer;
            
            staminaCurrValue = Mathf.Clamp(staminaCurrValue, 0, staminaMaxValue);
        }
        private void CalculateVelocity()
        {
            if(lastPos != transform.position) {
                velocity = transform.position - lastPos;
                velocity /= Time.deltaTime;
                lastPos = transform.position;
            }
            /*Vector3 currentPosition = transform.position;
            if (currentPosition != lastPos)
            {
                velocity = (currentPosition - lastPos) / deltaTime;
                lastPos = currentPosition;
            }*/
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
