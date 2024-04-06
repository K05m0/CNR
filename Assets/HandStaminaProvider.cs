using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets
{
    public class HandStaminaProvider : MonoBehaviour
    {
        public float staminaMaxValue;
        public float staminaCurrValue;
        [SerializeField] private float drainingStaminaMultiplayer;
        [SerializeField] private float regenerateStaminaMultiplayer;

        [SerializeField] private float recoveryTime;

        [SerializeField] private InteractionLayerMask baseMask;
        [SerializeField] private InteractionLayerMask nothingMask;
        
        public XRBaseController handController;
        public XRDirectInteractor interactor;
        
        public bool isDrainingStamina;

        public bool canHold = true;
        
        public int layerToManipulate;
        
        private void FixedUpdate()
        {
            if (isDrainingStamina)
                staminaCurrValue -= Time.deltaTime * drainingStaminaMultiplayer;
            else
                staminaCurrValue += Time.deltaTime * regenerateStaminaMultiplayer;

            staminaCurrValue = Mathf.Clamp(staminaCurrValue, 0, staminaMaxValue);
        }

        private void Update()
        {
            if (staminaCurrValue <= 0)
            {
                /*handController.enableInputActions = false;*/
                canHold = false;
                interactor.interactionLayers = nothingMask;
                StartCoroutine(Cooldown());
            }
            
        }

        private void Awake()
        {
            staminaCurrValue = staminaMaxValue;
        }

        public void StartDrainingStamina()
        {
            isDrainingStamina = true;
        }

        public void StomDrainingStamina()
        {
            isDrainingStamina = false;
        }

        private IEnumerator Cooldown()
        {
            yield return new WaitForSeconds(recoveryTime);
            handController.enableInputActions = true;
            interactor.interactionLayers = baseMask;
            canHold = true;
        }
    }
}
